using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public enum TokenState { Home, InPlay, Safe, Finish };
    public class Token
    {
        private int tokenId;
        private int tokenLocation;
        private int tokenStartLocation;
        private GameColor color;
        private TokenState state;


        public Token(int id, GameColor clr, int tsl)
        {
            this.tokenId = id;
            this.color = clr;
            this.state = TokenState.Home;
            this.tokenStartLocation = tsl;
            this.tokenLocation = this.tokenStartLocation;

        }
        public int GetTokenId()
        {
            return this.tokenId;
        }
        public GameColor GetColor()
        {
            return this.color;
        }
        public TokenState State
        {
            get { return this.state; } 
            set { this.state = value; }
        }
        //public TokenState SetState()
        //{
        //    this.state = value;
        //}
        
        public int TokenLocation
        {
            get { return this.tokenLocation; }
            set { this.tokenLocation = value; }
        }







    }
}
