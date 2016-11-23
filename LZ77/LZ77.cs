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
        private List<byte> decompressBuffer;

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

        public Boolean compress(String fileToRead)
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

            return true;
        }

        public Boolean decompress(String compressedFileToRead)
        {
            List<Token> decompressTokens = new List<Token>();
            BitReader bitReader = new BitReader(compressedFileToRead);

            FileInfo f = new FileInfo(compressedFileToRead);
            int nbr = 8 * (int)f.Length;

            int[] headerData = getOffsetAndLengthFromHeader(bitReader, nbr);
            decompressTokens = generateTokensForDecompression(bitReader, nbr, headerData);

            decompressBuffer = new List<byte>((int)Math.Pow(2, headerData[0] + headerData[1]));

            this.maxNoBitsForOffset = (int)Math.Pow(2, headerData[0]);
            this.maxNoBitsForLength = (int)Math.Pow(2, headerData[1]);
            int currentPosition = 0;

            foreach (Token token in decompressTokens)
            {
                if ((token.getOffset() == 0) && (token.getLength() == 0))
                   {
                       decompressBuffer.Add((byte)token.getCharacter());
                       currentPosition++;
                   }
                   else
                   {
                       var aux = currentPosition;
                       for (int i = 0; i < token.getLength(); i++)
                       {
                           decompressBuffer.Add(decompressBuffer[aux - token.getOffset() + i - 1]);
                           currentPosition++;
                       }
                       decompressBuffer.Add((byte)token.getCharacter());
                       currentPosition++;
                   }
               } 


            //generate the decompressed file
            String decompressedFile = "File.ext.o" + headerData[0] + "l" + headerData[1] + ".lz77.ext";
            BitWriter bitWriter = new BitWriter(decompressedFile);

            writeBufferToFile(decompressBuffer, bitWriter);

            return true;
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

        private List<Token> generateTokensForDecompression(BitReader bitReader, int fileSize, int[] headerData)
        {
            List<Token> decompressTokens = new List<Token>();
            Token token;

            int tokenOffset;
            int tokenLength;
            char tokenCharacter;
            
            // read 8b from header
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

        private void writeBufferToFile(List<byte> buffer, BitWriter bitWriter)
        {
            foreach (byte buf in buffer)
            {
                bitWriter.writeNBits(buf, 8);
            }
        }
    }
}
