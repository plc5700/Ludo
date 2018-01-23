using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public enum TokenState { Home, InPlay, Safe };
    public class Token
    {
        private int tokenId;
        private int tokenLocation;
        private int tokenStartLocation;
        private GameColor color;
        private TokenState state;


        public Token(int id, GameColor clr)
        {
            this.tokenId = id;
            this.color = clr;
            this.state = TokenState.Home;
            

        }
        public int GetTokenId()
        {
            return this.tokenId;
        }
        public GameColor GetColor()
        {
            return this.color;
        }
        public TokenState GetState()
        {
            return this.state;
        }
        public int GetLocation()
        {
            
           
                get { return this.tokenLocation; }
            
            this.tokenLocation = value;
        }







    }
}
