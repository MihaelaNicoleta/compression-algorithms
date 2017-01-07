using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    class Prediction
    {
        private int predictionType;
        private int[,] errorMatrix = new int[256, 256];

        public Prediction()
        {

        }

        public Prediction(int predictionType)
        {
            this.predictionType = predictionType;
        }

        public bool compress()
        {

            return true;
        }

        public bool decompress()
        {


            return true;
        }
    }
}
