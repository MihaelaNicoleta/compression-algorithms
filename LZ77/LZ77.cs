using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class LZ77
    {
        private int noBitsForOffset;
        private int noBitsForLength;

        private int maxNoBitsForOffset;
        private int maxNoBitsForLength;
        private List<Token> tokens = new List<Token>();

        private List<byte> entryBuffer;

        public LZ77() { }

        public LZ77(int noBitsForOffset, int noBitsForLength)
        {
            this.noBitsForOffset = noBitsForOffset;
            this.noBitsForLength = noBitsForLength;

            this.maxNoBitsForOffset = (int)Math.Pow(2, noBitsForOffset);
            this.maxNoBitsForLength = (int)Math.Pow(2, noBitsForLength);

            int bufferLength = (int)Math.Pow(2, noBitsForOffset + noBitsForLength);

            entryBuffer = new List<byte>(bufferLength);

        }

        public String compress(String fileToRead)
        {

            initializeBuffer(fileToRead);

            Token token;
            int slidingWindowOffset = 0;
            int currentPosition = 0;

            char tokenCharacter;
            int tokenOffset = 0;
            int tokenLength = 0;

            int patternLength = 0;
            int i = 0;
            int off = 0;

            var pos = 0;


            while ((currentPosition < entryBuffer.Count()) && (currentPosition < maxNoBitsForLength + entryBuffer.Count()))
            {
                tokenCharacter = (char)entryBuffer[currentPosition];

                if (currentPosition != 0)
                {
                    tokenLength = 0;
                    tokenOffset = 0;

                    for (off = 0; off < slidingWindowOffset; off++)
                    {
                        i = 0;
                        patternLength = 0;

                        pos = currentPosition - off + i - 1;
                        while ((pos < currentPosition) && (entryBuffer[pos] == entryBuffer[currentPosition + i]) && ((currentPosition + i) < maxNoBitsForLength))
                        {
                            i++;
                            patternLength++;
                            pos = currentPosition - off + i - 1;

                        }

                        if (i > 0)
                        {
                            if (patternLength > tokenLength)
                            {
                                tokenLength = patternLength;
                                tokenOffset = off;
                                tokenCharacter = (char)entryBuffer[currentPosition + i];

                            }
                        }
                    }

                    currentPosition += tokenLength + 1;
                }
                else {
                    currentPosition++;
                }


                if ((currentPosition > entryBuffer.Count) && (tokenLength > 0))
                {
                    token = new Token(tokenOffset, tokenLength - 1, (char)entryBuffer[currentPosition - 2]);
                    tokens.Add(token);
                }
                else
                {
                    var te = tokenLength;
                    token = new Token(tokenOffset, tokenLength, tokenCharacter);
                    tokens.Add(token);
                }

                slidingWindowOffset = ((currentPosition - maxNoBitsForOffset) > 0) ? (currentPosition - maxNoBitsForOffset) : (currentPosition);

            }

            //generate the compressed file
            String compressedFile = "File.ext.o" + noBitsForOffset + "l" + noBitsForLength + ".lz77";

            BitWriter bitWriter = new BitWriter(compressedFile);

            writeTokensToFile(tokens, bitWriter);

            return "compress";
        }

        public String decompress(String compressedFileToRead)
        {
            List<Token> decompressTokens = new List<Token>();
            BitReader bitReader = new BitReader(compressedFileToRead);

            FileInfo f = new FileInfo(compressedFileToRead);
            int nbr = 8 * (int)f.Length;

            decompressTokens = generateTokensForDecompression(bitReader, nbr);

            //generate the compressed file
            String decompressedFile = "File.ext.o" + noBitsForOffset + "l" + noBitsForLength + ".lz77.ext";
            BitWriter bitWriter = new BitWriter(decompressedFile);

            return "decompress";
        }


        private void initializeBuffer(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);
                entryBuffer.Add((byte)character);
                nbr -= 8;
            }

            bitReader.cleanUp();
        }

        private void writeTokensToFile(List<Token> tokens, BitWriter bitWriter)
        {
            writeHeader(bitWriter);

            foreach (Token token in tokens)
            {
                bitWriter.writeNBits(token.getOffset(), noBitsForOffset);
                bitWriter.writeNBits(token.getLength(), noBitsForLength);
                bitWriter.writeNBits(token.getCharacter(), 8);
            }

            bitWriter.writeNBits(0, 7);
            bitWriter.cleanUp();

        }

        private void writeHeader(BitWriter bitWriter)
        {
            bitWriter.writeNBits(noBitsForOffset, 5);
            bitWriter.writeNBits(noBitsForLength, 3);
        }

        public List<Token> getTokens()
        {
            return tokens;
        }

        private List<Token> generateTokensForDecompression(BitReader bitReader, int fileSize)
        {
            List<Token> decompressTokens = new List<Token>();
            Token token;

            int tokenOffset;
            int tokenLength;
            char tokenCharacter;

            int[] headerData = getOffsetAndLengthFromHeader(bitReader, fileSize);
            fileSize -= 8;

            int bitsRead = headerData[0] + headerData[1] + 8;

            while ((fileSize > 0) && (fileSize >= bitsRead))
            {
                tokenOffset = bitReader.readNBits(headerData[0]);
                tokenLength = bitReader.readNBits(headerData[1]);
                tokenCharacter = (char)bitReader.readNBits(8);

                token = new Token(tokenOffset, tokenLength, tokenCharacter);
                decompressTokens.Add(token);
                
                
                fileSize -= bitsRead;
            }

            bitReader.cleanUp();

            return decompressTokens;
        }

        private int[] getOffsetAndLengthFromHeader(BitReader bitReader, int fileSize)
        {
            int offsetFromHeader = 3;
            int lengthFromHeader = 2;

            int[] headerData = new int[2];

            if (fileSize > 0)
            {
                offsetFromHeader = bitReader.readNBits(5);
                lengthFromHeader = bitReader.readNBits(3);

                headerData[0] = offsetFromHeader;
                headerData[1] = lengthFromHeader;
            }
            
            return headerData;
        }
    }
}
