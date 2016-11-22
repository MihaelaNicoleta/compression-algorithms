using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class BitWriter
    {

        FileStream writer;
        byte buffer;
        int bitCount = 0;

        public BinaryWriter binaryWriter;

        public BitWriter(String filename)
        {
            writer = new FileStream(filename, FileMode.OpenOrCreate); 
            this.binaryWriter = new BinaryWriter(writer);
        }

        bool bufferFull()
        {
            return bitCount == 8;
        }

        bool bufferEmpty()
        {
            return bitCount == 0;
        }

        public void writeBit(int bit)
        {
            if (bufferFull()) /* if there there is room for one bit*/
            {
                writer.WriteByte((byte)buffer);
                bitCount = 0; /*no more bits in buffer*/

            }

            buffer = (byte)(buffer << 1); /*shift left to make room in LSB*/
            //bit = bit << 7; /*right LSB to MSB*/
            buffer += (byte)(0x01 & bit); /* put LSB of bit in LSB of buffer*/
            bitCount++; /*keep cont of the bits in buffer*/

            /*check if bitCount reached 8*/
            if (bufferFull())
            {
                writer.WriteByte((byte)buffer);
                bitCount = 0; /*no more bits in buffer*/

            }
        }

        public void writeNBits(int bits, int noBits)
        {

            bits = bits << (32 - noBits); /*bring the bits to the MSB*/

            for (int i = 0; i < noBits; i++)
            {
                byte bit = (byte)((0x80000000 & bits) >> 31); /*take the MSB*/
                writeBit(bit);
                bits = (int)(bits << 1); /*shift the rest to MSB*/
            }
        }

        public void cleanUp()
        {
            if (!bufferEmpty()) /*make sure you write all valid bits form buffer*/
            {
                writeNBits((byte)0, 7);
            }
            this.writer.Close();
        }

    }
}
