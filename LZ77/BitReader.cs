using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LZ77
{
    class BitReader
    {
        FileStream stream;
        byte buffer;
        int bitCount = 0;
        public BinaryReader binaryReader;

        public BitReader(String filename)
        {
            this.stream = new FileStream(filename, FileMode.OpenOrCreate);
            this.binaryReader = new BinaryReader(stream);
        }
        public long Position
        {
            get { return this.stream.Position; }
        }
        public long Length
        {
            get { return this.stream.Length; }
        }

        bool bufferEmpty()
        {
            return bitCount == 0;
        }



        public byte readBit()
        {
            byte bit = 0;

            if (bufferEmpty())/*check if buffer is empty*/
            {
                buffer = binaryReader.ReadByte(); /*read byte (8bits)*/
                bitCount = 8; /*update bit count*/
            }

            bit = (byte)((0x80 & buffer) >> 7); /*read MSB*/
            buffer = (byte)(buffer << 1); /*shift left to eliminate MSB*/
            bitCount--; /* decrement bitCount to know how many valid bits remains*/

            return bit;
        }
        public int readNBits(int noBits)
        {
            int bits = 0;

            for (int i = 0; i < noBits; i++)/*read bit by bit*/
            {
                bits = (int)(bits << 1); /*shift right to make room in LSB*/
                bits += (int)(readBit()); /*add read bit in LSB*/
            }

            return bits;
        }

        public bool canRead()
        {
            if (stream.Position != stream.Length)
            {
                return true;
            }
            else
            {
                if (this.bitCount > 0)
                {
                    return true;
                }
                return false;
            }
        }


        public void cleanUp()
        {
            this.binaryReader.Close();
        }

    }
}
