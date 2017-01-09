using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    class Histogram
    {

        //double scaleValue;

        public Histogram()
        {

        }

        public int[] getFrequenciesFromMatrix(int[,] matrix, int matrixSize)
        {
            int[] frequencies = new int[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                frequencies[i] = 0;
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int column = 0; column < matrixSize; column++)
                {
                    frequencies[matrix[row, column]]++;
                }
            }
            return frequencies;
        }

        public List<int> generateXAxesValuesList(int leftLimit, int rightLimit)
        {
            List<int> xAxesValues = new List<int>(rightLimit);

            for(int i = leftLimit; i < rightLimit; i++)
            {
                xAxesValues.Add(i);
            }

            return xAxesValues;

        }

    }
}
