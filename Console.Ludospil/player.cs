using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public class Player
    {

        private readonly int playerId;
        private readonly string name;
        private readonly Token[] tokens;
        private Field[] field;
        private Player[] players; 

        //private readonly Token[] token;

        public Player(int id, string playerName, Token[] tokens)
        {
            this.playerId = id;
            this.name = playerName;
            this.tokens = tokens;
            this.Color = this.tokens[0].GetColor();
        }
        public string GetName
        {
            get
            {
                return this.name;
            }
        }
        public GameColor Color;

        public int GetPlayerId()
        {
            return this.playerId;
        }
        public string GetDescription()
        {
            return "#" + this.GetPlayerId() + " " + this.Color + " spiller: " + this.GetName;
        }
        public Token[] GetTokens()
        {
            return this.tokens;
        }
        public Token[] GetToken()
        {
            return this.tokens;
        }
        public TokenState GetStat(int id)
        {
            return this.tokens[id].State;
        }
        public int TokenLocation(int id)
        {
            return this.tokens[id].TokenLocation;
        }
        public void Movetoken(int ds, int id, int ply, int tl/*, GameColor clr*/)
        {
            for (int i = 0; i < ds; i++)
            {
                if(i != ds  &&(tokens[id].TokenLocation == 58 || tokens[id].TokenLocation == 64 || tokens[id].TokenLocation == 70 || tokens[id].TokenLocation == 74))
                {
                    tokens[id].TokenLocation -= (ds - (i-1));
                    i = 6;
                }
                    if (tokens[id].State == TokenState.Home && ds == 6)
                    {
                        i = 6;
                        switch (Color)
                        {
                            case GameColor.Red:
                                tl = 1;
                                break;
                            case GameColor.Blu:
                                tl = 14;
                                break;
                            case GameColor.Yellow:
                                tl = 27;
                                break;
                            case GameColor.Green:
                                tl = 40;
                                break;
                        }
                    }
                    if (tl == 12 && Color == GameColor.Blu)
                         tl = 59; 
                    else if (tl == 25 && Color == GameColor.Yellow)
                         tl = 65; 
                    else if (tl == 38 && Color == GameColor.Green)
                         tl = 71;
                    else if (tl == 51 && Color == GameColor.Red)
                         tl = 53; 
                    else this.tokens[id].TokenLocation += 1;
            }
            //if(tokens[id].TokenLocation == 0)
            //    tokens[id].State = TokenState.Home;
            //else if (tokens[id].TokenLocation == 58 || tokens[id].TokenLocation == 64 || tokens[id].TokenLocation == 70 || tokens[id].TokenLocation == 76)
            //    tokens[id].State = TokenState.Finish;
            //else if (tokens[id].GetColor() == field[tokens[id].TokenLocation].GetColor())
            //    tokens[id].State = TokenState.Safe;
            //else tokens[id].State = TokenState.InPlay;
            int t1 = 4;
            int t2 = 4;
            foreach (Player pl in this.players)
            {
                for (int t = 0; t < 4; t++)
                {
                    if (pl.TokenLocation(t) == tokens[id].TokenLocation)
                    {
                        if (t1 == 4) { t1 = t; }
                        else { t2 = t; }
                        //if(pl.Color == players[ply].Color)
                        //{

                        //} 

                    }
                    if ((t1 < 4 && t2 < 4) && (pl.Color != players[ply].Color))//hvis 2 mod
                    {
                        tokens[id].TokenLocation = 0;
                    }
                    else if ((t1 < 4 && t2 < 4) && (pl.Color == players[ply].Color))//hvis 2 dine
                    {

                    }
                    else if ((t1 < 4 && t2 == 4) && (pl.Color != players[ply].Color))//hvis 1 mod
                    {
                        pl.tokens[t].TokenLocation = 0;
                    }
                    else if ((t1 < 4 && t2 == 4) && (pl.Color == players[ply].Color))//hvis 1 dine
                    {

                    }
                }
                
            }
        }   
    }
}
