﻿using System;
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
        public GameColor Color
        {
            get;
        }
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
            return this.tokens[id].GetState();
        }
        public int TokenLocation(int id)
        {
            return this.tokens[id].TokenLocation;
            
        }
        public void Movetoken(int ds, int id/*, GameColor clr*/)
        {
            for (int i = 0; i < ds; i++)
            {
                if (tokens[id].GetState() == TokenState.Home && ds == 6)
                {
                    i = 6;
                    switch (Color)
                    {
                        case GameColor.Red:
                            this.tokens[id].TokenLocation = 1;
                            break;
                        case GameColor.Blu:
                            this.tokens[id].TokenLocation = 14;
                            break;
                        case GameColor.Yellow:
                            this.tokens[id].TokenLocation = 27;
                            break;
                        case GameColor.Green:
                            this.tokens[id].TokenLocation = 40;
                            break;

                    }
                }
                if (tokens[id].TokenLocation==12 && Color == GameColor.Blu)
                    { this.tokens[id].TokenLocation = 59; }
                else if (tokens[id].TokenLocation == 25 && Color == GameColor.Yellow)
                    { this.tokens[id].TokenLocation = 65; }
                else if (tokens[id].TokenLocation == 38 && Color == GameColor.Green)
                    { this.tokens[id].TokenLocation = 71; }
                else if (tokens[id].TokenLocation == 51 && Color == GameColor.Red)
                    { this.tokens[id].TokenLocation = 53; }
                else
                    { this.tokens[id].TokenLocation += 1; }
                
            }
            if(tokens[id].s)
        }   
    }
}
