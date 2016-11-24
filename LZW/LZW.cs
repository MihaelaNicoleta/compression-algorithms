using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    class LZW
    {

        private Dictionary<int, List<String>> symbolDictionary;
        private int freeze;
        private int index;
        private int noOfSymbols = 3;

        public LZW() {
            symbolDictionary = new Dictionary<int, List<String>>();
        }

        public LZW(int freeze, int index)
        {
            this.freeze = freeze;
            this.index = index;
            int limit = (int)Math.Pow(2, index) - 1;
            symbolDictionary = new Dictionary<int, List<String>>(limit);
        }


        public Boolean compress(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            fillDictionaryFixedPart(symbolDictionary);
            List<String> list;

            String symbol = "";
            
            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);
                checkIfValueExists(symbolDictionary, "A");

                nbr -= 8;
            }

            bitReader.cleanUp();




            return true;
        }

        public Boolean decompress(String fileToRead)
        {
            return true;
        }

        private void fillDictionaryFixedPart(Dictionary<int, List<String>> symbolDictionary)
        {
            List<String> list;
            char character;
            String symbol;

            for (int i = 0; i < noOfSymbols; i++)
            {
                list = new List<String>();
                character = (char)i;
                symbol = character.ToString();

                list.Add(symbol);
                symbolDictionary.Add(i, list);
            }            
        }

        private bool checkIfValueExists(Dictionary<int, List<String>> symbolDictionary, String value)
        {
            List<String> list;
            foreach (KeyValuePair<int, List<String>> symbol in symbolDictionary)
            {
                list = symbol.Value;

                if (list.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
