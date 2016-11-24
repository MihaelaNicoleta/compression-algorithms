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
        List<int> encodedIndexes;

        public LZW() {
            symbolDictionary = new Dictionary<int, List<String>>();
            encodedIndexes = new List<int>();
        }

        public LZW(int freeze, int index)
        {
            this.freeze = freeze;
            this.index = index;
            int limit = (int)Math.Pow(2, index) - 1;
            symbolDictionary = new Dictionary<int, List<String>>(limit);
            encodedIndexes = new List<int>();
        }


        public Boolean compress(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            //fillDictionaryFixedPart(symbolDictionary);
            List<String> list;

            String symbol = "";
            
            list = new List<String>();
            list.Add("A");
            symbolDictionary.Add(0, list);
            list = new List<String>();
            list.Add("B");
            symbolDictionary.Add(1, list);
            list = new List<String>();
            list.Add("C");
            symbolDictionary.Add(2, list);
            list = new List<String>();
            list.Add("D");
            symbolDictionary.Add(3, list);

            int currentPosition = symbolDictionary.Count();

            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);

                var c = (char)character;
                var charString = c.ToString();

                if (checkIfValueExists(symbolDictionary, symbol+ charString))
                {
                    symbol = symbol + charString;
                }
                else
                {
                    list = new List<string>();
                    list.Add(symbol + charString); //symbol
                    list.Add(charString); //ultimul adaugat
                    symbolDictionary.Add(currentPosition, list);
                    symbol = charString;

                    currentPosition++;
                }
                nbr -= 8;
            }

            bitReader.cleanUp();

            String compressedFile = "File.ext." + ((freeze == 1) ? "f" : "e") + "l" + index + ".lzw";
            BitWriter bitWriter = new BitWriter(compressedFile);

            writeCompressedFile(symbolDictionary, bitWriter);


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

                if (list[0] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private void writeCompressedFile(Dictionary<int, List<String>> symbolDictionary, BitWriter bitWriter)
        {
            writeheader();


        }

        private void writeheader(BitWriter bitWriter)
        {
            bitWriter.writeBit(freeze);
            bitWriter.writeNBits(index, 4);
        }


    }
}
