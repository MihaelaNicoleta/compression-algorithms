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

        Bitmap histogramPicture;
        double scaleValue;

        public Histogram()
        {

        }

        public Histogram(double scaleValue)
        {
            this.scaleValue = scaleValue;
        }

        public Bitmap drawHistogram(int[,] matrix)
        {


            return histogramPicture;
        }


    }
}
