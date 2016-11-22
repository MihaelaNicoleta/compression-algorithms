using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanSemiStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            String testFileName = "test_file.txt";
            String compressedFileName = "compressed_file.txt";
            String decompressedFileName = "decompressed_file.txt";

            Huffman huff = new Huffman();
            huff.compress(testFileName, compressedFileName);
            huff.decompress(compressedFileName, decompressedFileName);
            Console.Read();
        }
    }
}
