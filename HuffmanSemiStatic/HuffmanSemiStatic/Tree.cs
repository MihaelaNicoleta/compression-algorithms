using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanSemiStatic
{
    class Tree
    {
        private Node root;

        public Tree()
        {
            root = null;
        }

        public Tree(char character)
        {
            root = new Node(character);
        }

        public Tree(Node node)
        {
            root = node;
        }

        public Node getTreeNode()
        {
            return root;
        }

        public void setTreeNode(Node node)
        {
            root = node;
        }
    }
}
