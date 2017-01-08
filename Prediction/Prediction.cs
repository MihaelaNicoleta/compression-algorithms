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
        private byte[,] pictureMatrix;
        private byte[,] errorMatrix;
        private byte[,] predictionMatrix;


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
            
            /* prediction matrix */
            predictionMatrix = getPredictedMatrix(pictureMatrix);

            /* error matrix */
            errorMatrix = getErrorMatrix(pictureMatrix, predictionMatrix);
            
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
        
        private byte[,] getPredictedMatrix(byte[,] pictureMatrix)
        {
            byte[,] bmpPredictionMatrix = new byte[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    bmpPredictionMatrix[row, column] = getPredictedValueForPixel(pictureMatrix, row, column);
                }
            }

            return bmpPredictionMatrix;
        }

        private byte[,] getErrorMatrix(byte[,] pictureMatrix, byte[,] predictionMatrix)
        {
            byte[,] bmpErrorMatrix = new byte[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    bmpErrorMatrix[row, column] = (byte)(pictureMatrix[row, column] - predictionMatrix[row, column]);
                }
            }

            return bmpErrorMatrix;
        }
        
        private byte getPredictedValueForPixel(byte[,] pictureMatrix, int row, int column)
        {
            return 0;
        }


        /* get pixel position */
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
        
        private bool isInternMatrixPixel(int row, int column)
        {
            return ((row != 0) && (column != 0));
        }

        public bool storeCompressedFile(String pictureName)
        {
            String compressedFile = pictureName + ".bmp[" + predictionType + "]" + ".pre";
            BitWriter bitWriter = new BitWriter(compressedFile);

            /* Copy the first 1078 bytes from the original bmp file */
            foreach(byte headerData in bitmapHeader)
            {
                bitWriter.writeNBits(headerData, 8);
            }

            /* Write another 4 BITS with the value meaning what prediction was selected */
            bitWriter.writeNBits(predictionType, 4);

            /* Write the error matrix using one of the 2 options */
            writeMatrix(bitWriter, 9, errorMatrix);

            return true;            
        }

        private void writeMatrix(BitWriter bitWriter, int noBits, byte[,] matrix)
        {
            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    bitWriter.writeNBits(matrix[row, column], noBits);
                }
            }
        }


    }
}
