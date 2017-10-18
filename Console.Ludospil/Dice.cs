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
            this.diceValue = this.rnd.Next(1, 7);
        }

        public int ThrowDice()
        {
            
            this.diceValue = rnd.Next(1, 7);
            for (int i = 3; i > 0; i--)
			{
				Console.Write(" . ");
				System.Threading.Thread.Sleep(500);

			}
            return this.diceValue;
        }

        public int GetValue()
        {
            return this.diceValue;

        }
 

    }
}
