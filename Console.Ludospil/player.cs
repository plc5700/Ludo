using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public class Player
    {

        private Token[] tokens = new Token[4];
        private GameColor color;
        private readonly string name;
        public Player(string PlayerName, GameColor clr )
        {
            this.name = PlayerName;
            this.color = clr;
            CreateTokens(clr);
        }
        private void CreateTokens(GameColor clr)
        {
            for(int i = 0; i<= 3; i++)
            {
                this.tokens[i] = new Token(clr);

            }
        }

        public string GetName

        {
            get{
                return this.name;
            }

        }
        public GameColor GetColor
        {
            get
            {
                return this.color;
            }

        }
        public Token[] GetToken
            
        {
            get
            {
                return this.tokens;
            }
        }

    }
}
