using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public class Token
    {
        int[] yellowTokens = new int[4], grenTokens = new int[4], bluTokens = new int[4], redTokens = new int[4];
        private GameColor color;

        public Token(GameColor color)
        {
            this.color = color;
        }
        public GameColor GetColor()
        {
            return this.color;
        }

    }
}
