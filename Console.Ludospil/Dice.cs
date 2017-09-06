using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public class Dice
    {
        Random rnd = new Random();
        private int diceValue;

        public Dice()
        {
            this.ThrowDice();

        }

        public int ThrowDice()
        {
            
            this.diceValue = rnd.Next(1, 7);

            return this.diceValue;
        }

        public int GetValue()
        {
            return this.diceValue;

        }


    }
}
