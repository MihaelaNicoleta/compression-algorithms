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
        private int[,] pictureMatrix;
        private int[,] errorMatrix;
        private int[,] predictionMatrix;


        int[] bitmapHeader;

        public Prediction()
        {
            errorMatrix = new int[bitmapSize, bitmapSize];
            pictureMatrix = new int[bitmapSize, bitmapSize];
            bitmapHeader = new int[bitmapHeaderSize];
    }

        public Prediction(int predictionType)
        {
            this.predictionType = predictionType;
            errorMatrix = new int[bitmapSize, bitmapSize];
            pictureMatrix = new int[bitmapSize, bitmapSize];
            bitmapHeader = new int[bitmapHeaderSize];
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

            //writeMatrixToConsole(errorMatrix);
            //Console.WriteLine("------------------------------------");
            
            return true;
        }

        public bool decompress(String compressedFileToRead)
        {
            BitReader bitReader = new BitReader(compressedFileToRead);

            /* read header */
            bitmapHeader = getHeaderFromPicture(bitReader, bitmapHeaderSize);

            /* prediction type */
            predictionType = bitReader.readNBits(4);

            /* error matrix */
            errorMatrix = getErrorMatrixFromCompressedFile(bitReader, 9);

            /* picture matrix */
            pictureMatrix = getPictureMatrixFromCompressedFile();

            bitReader.cleanUp();

            return true;
        }


        private int[,] getMatrixFromPicture(BitReader bitReader)
        {
            int[,] pictureMatrix = new int[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    pictureMatrix[row, column] = (int)bitReader.readNBits(8);
                }
            }

            return pictureMatrix;
        }

        private int[] getHeaderFromPicture(BitReader bitReader, int noBitsToRead)
        {
            int[] bmpHeader = new int[bitmapHeaderSize];

            for(int i = 0; i < bitmapHeaderSize; i++)
            {
                bmpHeader[i] = (int)bitReader.readNBits(8);
            }

            return bmpHeader;
        }

        private void setPixelValue(int row, int column, int valueForPixel)
        {
            pictureMatrix[row, column] = valueForPixel;
        }
        
        private int[,] getPredictedMatrix(int[,] pictureMatrix)
        {
            int[,] bmpPredictionMatrix = new int[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    bmpPredictionMatrix[row, column] = getPredictedValueForPixel(pictureMatrix, row, column);
                }
            }

            return bmpPredictionMatrix;
        }

        private int[,] getErrorMatrix(int[,] pictureMatrix, int[,] predictionMatrix)
        {
            int[,] bmpErrorMatrix = new int[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    bmpErrorMatrix[row, column] = (int)(pictureMatrix[row, column] - predictionMatrix[row, column]);
                }
            }

            return bmpErrorMatrix;
        }
        
        private int getPredictedValueForPixel(int[,] pictureMatrix, int row, int column)
        {
            if(isFirstPixel(row, column))
            {
                return (int)(bitmapSize / 2);
            }
            else
            {
                if(isRowZeroPixel(row))
                {
                    return getAFromMatrix(row, column);
                }
                else
                {
                    if(isColumnZeroPixel(column))
                    {
                        return getBFromMatrix(row, column);
                    }
                    else
                    {
                        return getValueFromPredictor(row, column);
                    }
                }
            }
        }

        private int getValueFromPredictor(int row, int column)
        {
            int predictedValue = 0;
            int temp;

            int a = getAFromMatrix(row, column);
            int b = getBFromMatrix(row, column);
            int c = getCFromMatrix(row, column);

            switch (predictionType)
            {
                case 0: /* 128 prediction */
                    {
                        predictedValue = (int)(bitmapSize / 2);
                        break;
                    }
                case 1: /* A prediction*/
                    {
                        predictedValue = a;
                        break;
                    }
                case 2: /* B prediction */
                    {
                        predictedValue = b;
                        break;
                    }
                case 3: /* C prediction */
                    {
                        predictedValue = c;
                        break;
                    }
                case 4: /* A+B-C prediction */
                    {
                        temp = a + b - c;
                        predictedValue = (int)getPixelValueWithinInterval(temp);
                        break;
                    }
                case 5: /* A+(B-C)/2 prediction */
                    {
                        temp = a + (b - c) / 2;
                        predictedValue = (int)getPixelValueWithinInterval(temp);
                        break;
                    }
                case 6: /* B+(A-C)/2 prediction */
                    {
                        temp = b + (a - c) / 2;
                        predictedValue = (int)getPixelValueWithinInterval(temp);
                        break;
                    }
                case 7: /* (A+B)/2 prediction */
                    {
                        temp = (a + b) / 2;
                        predictedValue = (int)getPixelValueWithinInterval(temp);
                        break;
                    }
                case 8: /* jpegLS prediction */
                    {
                        var min = Math.Min(a, b);
                        var max = Math.Max(a, b);

                        if (c >= max)
                        {
                            predictedValue = min;
                        }
                        else
                        {
                            if(c <= min)
                            {
                                predictedValue = max;
                            }
                            else
                            {
                                predictedValue = (int)(a + b - c);
                            }
                        }

                        break;
                    }
            }

            return predictedValue;
        }

        /* get pixel position */
        private int getAFromMatrix(int row, int column)
        {
            return pictureMatrix[row, column - 1];
        }

        private int getBFromMatrix(int row, int column)
        {
            return pictureMatrix[row - 1, column];
        }

        private int getCFromMatrix(int row, int column)
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

        public String storeCompressedFile(String pictureName)
        {
            String compressedFile = pictureName + ".bmp[" + predictionType + "]" + ".pre";
            BitWriter bitWriter = new BitWriter(compressedFile);

            /* Copy the first 1078 ints from the original bmp file */
            foreach(int headerData in bitmapHeader)
            {
               bitWriter.writeNBits((int)headerData, 8);
            }

            /* Write another 4 BITS with the value meaning what prediction was selected */
            bitWriter.writeNBits(predictionType, 4);

            /* Write the error matrix using one of the 2 options */
            writeMatrixToFile(bitWriter, 9, errorMatrix);

            bitWriter.cleanUp();

            return compressedFile;            
        }

        public String storeDecompressedFile(String pictureName)
        {
            String compressedFile = pictureName + ".bmp[" + predictionType + "]" + ".pre.decoded";
            BitWriter bitWriter = new BitWriter(compressedFile);

            /* Copy the first 1078 ints from the original bmp file */
            foreach (int headerData in bitmapHeader)
            {
                bitWriter.writeNBits((int)headerData, 8);
            }

            /* Write the error matrix using one of the 2 options */
            //writeMatrixToFile(bitWriter, 9, pictureMatrix);

            bitWriter.cleanUp();

            return compressedFile;
        }

        private void writeMatrixToFile(BitWriter bitWriter, int noBits, int[,] matrix)
        {
            int valueToWrite;
            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    valueToWrite = matrix[row, column];
                    if (valueToWrite < 0)
                    {
                        bitWriter.writeBit(1); //1 = negative
                        valueToWrite = valueToWrite * (-1);
                    }
                    else
                    {
                        bitWriter.writeBit(0); //0 = positive
                    }
                    bitWriter.writeNBits(valueToWrite, noBits - 1);
                }
            }

        }

        public Bitmap createBitmapFromMatrix(int[,] matrix, double scaleValue)
        {
            Bitmap bitmapFromMatrix = new Bitmap(bitmapSize, bitmapSize);

            int pixel;
            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    pixel = (int)((bitmapSize/2) + matrix[row, column] * scaleValue);
                    bitmapFromMatrix.SetPixel(column, row, getColorValueForPixel(pixel));
                }
            }

            return bitmapFromMatrix;      
        }

        private int getPixelValueWithinInterval(int pixel)
        {
            if (pixel < 0)
            {
                pixel = 0;
            }
            else
            {
                if (pixel > bitmapSize - 1)
                {
                    pixel = bitmapSize - 1;
                }
            }

            return pixel;
        }

        private Color getColorValueForPixel(int pixelValue)
        {
            pixelValue = getPixelValueWithinInterval(pixelValue);
            return Color.FromArgb(pixelValue, pixelValue, pixelValue);
        }

        private int[,] getErrorMatrixFromCompressedFile(BitReader bitReader, int noBits)
        {
            int[,] errorMatrixFromFile = new int[bitmapSize, bitmapSize];

            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    var positivity = bitReader.readBit();                                        
                    errorMatrixFromFile[row, column] = bitReader.readNBits(noBits - 1);

                    if (positivity == 1)
                    {
                        errorMatrixFromFile[row, column] = errorMatrixFromFile[row, column] * (-1);
                    }
                }
            }

            return errorMatrixFromFile;
        }

        private int[,] getPictureMatrixFromCompressedFile()
        {
            int predictedValue;
            int pictureMatrixValue;
            int[,] imageMatrix = new int[bitmapSize, bitmapSize];
            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    predictedValue = getPredictedValueForPixel(imageMatrix, row, column);
                    pictureMatrixValue = predictedValue + errorMatrix[row, column];
                    imageMatrix[row, column] = pictureMatrixValue;
                    setPixelValue(row, column, pictureMatrixValue);
                }               
            }

            return imageMatrix;

        }


        /* for UI */

        public int[,] getPredictionErrorMatrix()
        {
            return errorMatrix;
        }

        public int[,] getPredictionPictureMatrix()
        {
            return pictureMatrix;
        }

        public void writeMatrixToConsole(int[,] matrix)
        {
            for (int row = 0; row < bitmapSize; row++)
            {
                for (int column = 0; column < bitmapSize; column++)
                {
                    Console.Write(matrix[row, column]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }
}
