using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class Token
    {

        private int offset;
        private int length;
        private char character;

        public Token(int offset, int length, char character)
        {
            this.offset = offset;
            this.length = length;
            this.character = character;
        }

        public int getOffset()
        {
            return this.offset;
        }

        public int getLength()
        {
            return this.length;
        }

        public int getCharacter()
        {
            return this.character;
        }

        public void setOffset(int offset)
        {
            this.offset = offset;
        }

        public void setLength(int length)
        {
            this.length = length;
        }

        public void setCharacter(char character)
        {
            this.character = character;
        }


    }
}
