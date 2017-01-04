using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanSemiStatic
{
    class Node
    {

        private Node parentNode;
        private Node leftNode;
        private Node rightNode;
        private int appearances;
        private char character;
        private String compressCode;
        
        public Node(char newCharacter)
        {
            parentNode = null;
            leftNode = null;
            rightNode = null;
            appearances = 0;
            character = newCharacter;
            compressCode = "";
        }

        public Node getParentNode()
        {
            return parentNode;
        }

        public Node getLeftNode()
        {
            return leftNode;
        }

        public Node getRightNode()
        {
            return rightNode;
        }

        public int getAppearances()
        {
            return appearances;
        }

        public char getCharacter()
        {
            return character;
        }

        public String getCompressCode()
        {
            return compressCode;
        }

        public void setParentNode(Node node)
        {
            parentNode = node;
        }

        public void setLeftNode(Node node)
        {
            leftNode = node;
        }

        public void setRightNode(Node node)
        {
            rightNode = node;
        }

        public void setAppearances(int contor)
        {
            appearances = contor;
        }

        public void setCharacter(char newCharacter)
        {
            character = newCharacter;
        }

        public void setCompressCode(String code)
        {
            compressCode = code;
        }

    }
}
