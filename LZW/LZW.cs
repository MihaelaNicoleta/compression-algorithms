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
        private Dictionary<int, List<String>> symbolDecompressDictionary;
        List<String> decompressedResult = new List<String>();
        private int freeze;
        private int index;
        private int noOfSymbols = 256;
        private int indexMaxSize;

        public LZW() {
            symbolDictionary = new Dictionary<int, List<String>>();
        }

        public LZW(int freeze, int index)
        {
            this.freeze = freeze;
            this.index = index;
            indexMaxSize = (int)Math.Pow(2, index) - 1;
            symbolDictionary = new Dictionary<int, List<String>>(indexMaxSize);
        }


        public Boolean compress(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            fillDictionaryFixedPart(symbolDictionary);            

            String symbol = "";
            List<String> list;

            int currentPosition = symbolDictionary.Count();
            
            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);

                var c = (char)character;
                var charString = c.ToString();

                int charIndex = getIndexFromDictionary(symbolDictionary, symbol + charString);
                if ((charIndex != -1) && (charIndex <= indexMaxSize))
                {
                    symbol = symbol + charString;
                }
                else
                {
                    if (symbolDictionary.Count > indexMaxSize)
                    {
                        if (freeze == 0)
                        {
                            symbolDictionary.Clear();
                            fillDictionaryFixedPart(symbolDictionary);                           
                        }
                    }
                    list = new List<string>();
                    list.Add(symbol + charString);
                    list.Add(symbol); 
                    symbolDictionary.Add(currentPosition, list);
                    currentPosition++;
                    
                    symbol = charString;                  
                }

                nbr -= 8;

                if(nbr <= 0)
                {
                    list = new List<string>();
                    list.Add(symbol + charString);
                    list.Add(symbol);
                    symbolDictionary.Add(currentPosition, list);
                }
            }

            bitReader.cleanUp();

            String compressedFile = "File.ext." + ((freeze == 1) ? "f" : "e") + "l" + index + ".lzw";
            BitWriter bitWriter = new BitWriter(compressedFile);

            writeCompressedFile(symbolDictionary, bitWriter);

            bitWriter.cleanUp();

            return true;
        }

        public Boolean decompress(String compressedFileToRead)
        {
            BitReader bitReader = new BitReader(compressedFileToRead);

            FileInfo f = new FileInfo(compressedFileToRead);
            int nbr = 8 * (int)f.Length;

            symbolDecompressDictionary = new Dictionary<int, List<string>>();

            fillDictionaryFixedPart(symbolDecompressDictionary);

            String symbol = "";
            List<String> list;
                        
            int currentPosition = noOfSymbols;
            int[] headerData = getDataFromHeader(bitReader, nbr);
            nbr -= 5;

            this.freeze = headerData[0];
            this.index = headerData[1];

            int characterIndex = bitReader.readNBits(index);
            var charString = symbolDecompressDictionary[characterIndex][0];

            decompressedResult.Add(charString);
            symbol = charString;
            nbr -= index;
            
            while(nbr >= index + 8)
            {
                characterIndex = bitReader.readNBits(index);
                
                if (characterIndex >= symbolDecompressDictionary.Count)
                {
                    charString = symbol + symbol[0];
                }                    
                else
                {
                    charString = symbolDecompressDictionary[characterIndex][0];
                }

                decompressedResult.Add(charString);

                if (symbolDictionary.Count > indexMaxSize)
                {
                    if (freeze == 0)
                    {
                        symbolDecompressDictionary.Clear();
                        fillDictionaryFixedPart(symbolDecompressDictionary);
                    }
                }
                list = new List<string>();
                list.Add(symbol + charString[0]);
                symbolDecompressDictionary.Add(currentPosition, list);
                currentPosition++;                    
               
                symbol = charString;
                nbr -= index;

            }
                        
            //generate the decompressed file
            String decompressedFile = "File.ext." + ((freeze == 1) ? "f" : "e") + "l" + index + ".lzw.ext";
            BitWriter bitWriter = new BitWriter(decompressedFile);

            writeDecompressedDataToFile(decompressedResult, bitWriter);
            bitWriter.cleanUp();

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

        private void writeCompressedFile(Dictionary<int, List<String>> symbolDictionary, BitWriter bitWriter)
        {
            writeheader(bitWriter);

            Dictionary<int, List<String>> dictionaryFromInput = getDictionaryElements();

            int valueIndex = 0;

            foreach (KeyValuePair<int, List<String>> symbol in dictionaryFromInput)
            {
                var element = (symbol.Key != noOfSymbols) ? symbol.Value[1] : symbol.Value[0][0].ToString();
                valueIndex = getIndexFromDictionary(symbolDictionary, element);
                bitWriter.writeNBits(valueIndex, index);                
            }

            bitWriter.writeNBits(0, 7);
        }

        private void writeheader(BitWriter bitWriter)
        {
            bitWriter.writeBit(freeze);
            bitWriter.writeNBits(index, 4);
        }

        private int getIndexFromDictionary(Dictionary<int, List<String>> symbolDictionary, String value)
        {
            List<String> list;
            foreach (KeyValuePair<int, List<String>> symbol in symbolDictionary)
            {
                list = symbol.Value;

                if (list[0] == value)
                {
                    return symbol.Key;
                }
            }

            return -1;
        }

        public Dictionary<int, List<String>> getDictionaryElements()
        {
            return symbolDictionary.Skip(noOfSymbols)
                      .Take(symbolDictionary.Count - noOfSymbols)
                      .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        
        private void writeDecompressedDataToFile(List<String> results, BitWriter bitWriter)
        {
            foreach (String result in results)
            {
                for(int i = 0; i < result.Length; i++)
                {
                    bitWriter.writeNBits(result[i], 8);
                }                
            }
        }

        private int[] getDataFromHeader(BitReader bitReader, int fileSize)
        {
            int freeze;
            int indexFromHeader;

            int[] headerData = new int[2];

            if (fileSize > 0)
            {
                freeze = bitReader.readBit();
                indexFromHeader = bitReader.readNBits(4);

                headerData[0] = freeze;
                headerData[1] = indexFromHeader;
            }
            return headerData;
        }
    }
}
