
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public enum GameColor { Yellow, Green, Blu, Red }

    public class Game

    {
        private int numberOfPlayers;
        private Player[] players;
        public Game()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("Velkommen til Ludo");
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            
        }
        //private string WhoStarts()
        //{
        //    int[] startKast;
        //    char k = 'j';
        //    for (int i = 0; i < this.numberOfPlayers; i++)
        //    {
        //        Console.WriteLine("{0:S} slå så vi kan se hvem der starter (tryk k for at kaste)", players[i]);
        //        while (k != 'k')
        //        {
        //            k = Console.ReadKey().KeyChar;
        //        }

        //    }
                
        //}
        
        private void SetNumberOfPlayers()
        {
            Console.Write("Hvor mange spillere?: ");
            // if (int.TryParse(Console.ReadKey().KeyChar, out this.numberOfPlayers))
            //{ } //throw new ArgumentException(");
            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if(!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ugyldig værdi, vælg et tal mellem 2 og 4");
                }
            }
        }

        private void CreatePlayers()
        {
            this.players = new Player[this.numberOfPlayers];
            for (int i = 0; i < this.numberOfPlayers; i++)
            {
                Console.WriteLine();
                Console.Write("Hvad hedder spiller {0}: ", (i + 1));
                string name = Console.ReadLine();

                GameColor clr = GameColor.Red;
                switch (i)

                {
                    case 0:
                        clr = GameColor.Red;
                        break;
                    case 1:
                        clr = GameColor.Blu;
                        break;
                    case 2:
                        clr = GameColor.Yellow;
                        break;
                    case 3:
                        clr = GameColor.Green;
                        break;

                }
                this.players[i] = new Player(name, clr);
            }
        }

        private void ShowPlayers()
        {
            Console.WriteLine();
            Console.WriteLine("Okay, her er dine spillere:");
            foreach (Player pl in this.players)
            {
                Console.WriteLine(pl.GetColor  pl.GetName);
            }
            Console.WriteLine();
        }
    }
}
