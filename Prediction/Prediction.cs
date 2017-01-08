using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    class Prediction
    {
        int bitmapSize = 256;
        int bitmapHeaderSize = 1078;

        private int predictionType;
        private byte[,] errorMatrix;
        private byte[,] pictureMatrix;

        byte[] bitmapHeader;

        public Prediction()
        {
            errorMatrix = new byte[bitmapSize, bitmapSize];
            pictureMatrix = new byte[bitmapSize, bitmapSize];
            bitmapHeader = new byte[bitmapHeaderSize];
    }

        public Prediction(int predictionType)
        {
            this.predictionType = predictionType;
            errorMatrix = new byte[bitmapSize, bitmapSize];
            pictureMatrix = new byte[bitmapSize, bitmapSize];
            bitmapHeader = new byte[bitmapHeaderSize];
        }

        public bool compress(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);
            bitmapHeader = getHeaderFromPicture(bitReader, bitmapHeaderSize);

            /* original picture matrix */
            pictureMatrix = getMatrixFromPicture(bitReader);







            bitReader.cleanUp();
            
            return true;
        }

        public bool decompress()
        {


            return true;
        }


        private byte[,] getMatrixFromPicture(BitReader bitReader)
        {
            byte[,] pictureMatrix = new byte[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    pictureMatrix[row, column] = (byte)bitReader.readNBits(8);
                }
            }

            return pictureMatrix;
        }

        private byte[] getHeaderFromPicture(BitReader bitReader, int noBitsToRead)
        {
            byte[] bmpHeader = new byte[noBitsToRead];

            for(int i = 0; i < noBitsToRead; i += 8)
            {
                bmpHeader[i] = (byte)bitReader.readNBits(8);
            }

            return bmpHeader;
        }

        private void setPixelValue(int row, int column, byte valueForPixel)
        {
            pictureMatrix[row, column] = valueForPixel;
        }

        private byte getAFromMatrix(int row, int column)
        {
            return pictureMatrix[row, column - 1];
        }

        private byte getBFromMatrix(int row, int column)
        {
            return pictureMatrix[row - 1, column];
        }

        private byte getCFromMatrix(int row, int column)
        {
            return pictureMatrix[row - 1, column - 1];
        }

        private bool isFirstPixel(int row, int column)
        {
            return ((row == 0) && (column == 0));
        }

        private bool isRowZeroPixel(int row)
        {
            return row == 0;
        }

        private bool isColumnZeroPixel(int column)
        {
            return column == 0;
        }



    }
}
