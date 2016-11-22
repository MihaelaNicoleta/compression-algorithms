using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanSemiStatic
{
    class Huffman
    {
        public const int number_of_symbols = 256;
        private int[] compressFrequency = new int[number_of_symbols];
        private int[] decompressFrequency = new int[number_of_symbols];
        private Dictionary<int, List<int>> codes = new Dictionary<int, List<int>>();

        private int compressedFileSize = 0;

        public Huffman()
        {
            for (int i = 0; i < number_of_symbols; i++)
            {
                compressFrequency[i] = 0;
                decompressFrequency[i] = 0;
            }
        }

        public void compress(String inputFile, String outputFile)
        {
            //1. Determinare statistica
            getStatistics(inputFile);

            //2. Construire model
            List<Tree> sortedListOfTrees = new List<Tree>();
            sortedListOfTrees = sortListOfTrees(compressFrequency);

            Tree huffmanTree = new Tree();
            huffmanTree = buildHuffmanModel(sortedListOfTrees);

            //3. Codare pe baza modelului
            listTreeInOrder(huffmanTree.getTreeNode());

            //4. Creeaza fisier comprimat
            writeCompressedFile(inputFile, outputFile);
               
        }
        public void decompress(String inputFile, String outputFile)
        {
            //1. Preluare statistica
            getStatisticsFromHeader(inputFile);

            //2. Construire model
            List<Tree> sortedListOfTrees = new List<Tree>();
            sortedListOfTrees = sortListOfTrees(decompressFrequency);

            Tree huffmanTree = new Tree();
            huffmanTree = buildHuffmanModel(sortedListOfTrees);

            //3. Creeaza fisier decomprimat
            writeDecompressedFile(huffmanTree, inputFile, outputFile);
            
        }

        
        private void getStatistics(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;    

            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);
                compressFrequency[character]++;
                nbr -= 8;
            }

            bitReader.cleanUp();
        }
        
        private List<Tree> sortListOfTrees(int[] frequency)
        {
            List<Tree> listOfTrees = new List<Tree>();
            listOfTrees = createListOfTrees(frequency);
            listOfTrees.Sort((x, y) => x.getTreeNode().getAppearances().CompareTo(y.getTreeNode().getAppearances()));

            return listOfTrees;
        }

        private List<Tree> createListOfTrees(int[] frequency)
        {
            List<Tree> listOfTrees = new List<Tree>();
            Node toBeAdded;

            for (int i = 0; i < frequency.Length; i++)
            {
                if(frequency[i] != 0)
                {
                    toBeAdded = new Node((char)i);
                    toBeAdded.setAppearances(frequency[i]);

                    listOfTrees.Add(new Tree(toBeAdded));
                }
            }

            return listOfTrees;          
        }

        private Tree buildHuffmanModel(List<Tree> sortedTrees)
        {
            //until we have only one tree in the list
            Tree combinedTree;
            Node temporaryNode;

            while (sortedTrees.Count != 1)
            {
                temporaryNode = new Node((char)(sortedTrees[0].getTreeNode().getCharacter() + sortedTrees[1].getTreeNode().getCharacter()));
                temporaryNode.setAppearances(sortedTrees[0].getTreeNode().getAppearances() + sortedTrees[1].getTreeNode().getAppearances());
                temporaryNode.setParentNode(null);
                temporaryNode.setLeftNode(sortedTrees[0].getTreeNode());
                temporaryNode.setRightNode(sortedTrees[1].getTreeNode());
                               
                combinedTree = new Tree(temporaryNode);

                sortedTrees[0].getTreeNode().setParentNode(combinedTree.getTreeNode());
                sortedTrees[1].getTreeNode().setParentNode(combinedTree.getTreeNode());

                sortedTrees[0].getTreeNode().setCompressCode("0");
                sortedTrees[1].getTreeNode().setCompressCode("1");

                sortedTrees.RemoveRange(0, 2);
                sortedTrees.Insert(0, combinedTree);

                sortedTrees.Sort((x, y) => x.getTreeNode().getAppearances().CompareTo(y.getTreeNode().getAppearances()));
      
            }
                        
            return sortedTrees[0];
        }

        private void listTreeInOrder(Node node)
        {
            List<int> codeAndLength = new List<int>();

            if (node != null)
            {
                listTreeInOrder(node.getLeftNode());
                if ((node.getLeftNode() == null) && (node.getRightNode() == null))
                {
                    String code = reverseCode(node);
                    node.setCompressCode(code);

                    codeAndLength.Add(Convert.ToInt32(node.getCompressCode(), 2));
                    codeAndLength.Add(node.getCompressCode().Length);
                    codes.Add(node.getCharacter(), codeAndLength);

                    Console.Write(node.getCharacter() + " ");
                    Console.Write(node.getCompressCode() + " ");
                    Console.WriteLine();
                }

                listTreeInOrder(node.getRightNode());
            }
           
        }

        private string reverseCode(Node node)
        {
            String reverseCode = "";

            while (node.getParentNode() != null)
            {
                reverseCode += node.getCompressCode().ToString();
                node = node.getParentNode();
            }

            if ((node.getParentNode() == null) && (node.getLeftNode() == null) && (node.getRightNode() == null))
            {
                reverseCode += node.getCompressCode().ToString();
            }
            
            char[] charArray = reverseCode.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }

        private void writeCompressedFile(String fileToRead, String fileToWrite)
        {
            BitReader bitReader = new BitReader(fileToRead);
            BitWriter bitWriter = new BitWriter(fileToWrite);
  
            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;


            writeHeader(bitWriter);
            
            while (nbr > 0)
            {
                int character = bitReader.readNBits(8);
                
                //[0] - cod binar, [1] - dimensiune cod               
                bitWriter.writeNBits(codes[character][0], codes[character][1]);
                nbr -= 8;
            }

            bitWriter.writeNBits(0, 7);

            bitReader.cleanUp();
            bitWriter.cleanUp();
        }

        private void writeHeader(BitWriter bitWriter)
        {
            foreach (int f in compressFrequency)
            {
                bitWriter.writeBit((f == 0) ? 0 : 1);
            }
            var ctor = 0;
            foreach (int f in compressFrequency)
            {
                
                if(f != 0)
                {
                    bitWriter.writeNBits(f, 32);
                }
                ctor++;                
            }
        }

        private void getStatisticsFromHeader(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);
            List<int> existingCharsFrequency = new List<int>();
            
            for (int i = 0; i < number_of_symbols; i++)
            {
                decompressFrequency[i] = bitReader.readBit();
                if(decompressFrequency[i] == 1)
                {
                    existingCharsFrequency.Add(i);
                }
                compressedFileSize++;
            }
            
            foreach (int c in existingCharsFrequency)
            {                
                decompressFrequency[c] = (int)bitReader.readNBits(32);
                compressedFileSize = compressedFileSize+32;
            }
            
            bitReader.cleanUp();
        }

        private void writeDecompressedFile(Tree huffmanTree,  String fileToRead, String fileToWrite)
        {
            BitReader bitReader = new BitReader(fileToRead);
            BitWriter bitWriter = new BitWriter(fileToWrite);

            Node node;

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            int currentBit;
            
            //start reading after the header
            for (int i = 0; i < compressedFileSize; i++)
            {
               currentBit = bitReader.readBit();
            }
            
            int noBitsToBeReadFromFile = 0;
            int noBitsRead = 0;
            bool endOfDataStream = true;

            List<int> charactersAppeared = new List<int>();

            while(endOfDataStream == true)
            {
                int noBitsOfCopmpressCode = 0; //pe cati biti e scris codul

                node = huffmanTree.getTreeNode();               
                
                while ((node.getLeftNode() != null) && (node.getRightNode() != null))
                {                    
                    noBitsRead++;
                    noBitsOfCopmpressCode++;

                    currentBit = bitReader.readBit();
                    if (currentBit == 0)
                    {
                        node = node.getLeftNode();
                    }
                    else
                    {
                        node = node.getRightNode();
                    }
                }

                var character = node.getCharacter();
                var characterFrequency = decompressFrequency[character];
                
                if(!charactersAppeared.Contains(character))
                {
                    charactersAppeared.Add(character);
                    noBitsToBeReadFromFile += characterFrequency * noBitsOfCopmpressCode;
                }

                if(noBitsRead > noBitsToBeReadFromFile)
                {
                    endOfDataStream = false;
                }
                else
                {
                    bitWriter.writeNBits(node.getCharacter(), 8);
                }                
                
            }

            bitReader.cleanUp();
            bitWriter.cleanUp();
        }
    }
}
