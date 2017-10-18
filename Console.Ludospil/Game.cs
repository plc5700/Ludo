
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public enum GameColor { Yellow, Green, Blu, Red };
    public enum GameState {Inplay, Finished};

    public class Game
    {
        private GameState state;
        private int delay = 500;

        private int numberOfPlayers;
        private Player[] players;
        private int playerTurn = 1;
        private Dice dice = new Dice();

        public Game()
        {
            Console.WriteLine("Velkommen til Ludo");
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            state = GameState.Inplay;
            TakeTurns();
        }

        private void clear()
        {
            Console.Clear();
            Console.WriteLine("---------- Ludo ----------");
            Console.WriteLine();
        }

        private void pause(int dl)
        {
            System.Threading.Thread.Sleep(dl);
        }

        private void SetNumberOfPlayers()
        {
            Console.Write("Hvor mange spillere?: ");
           
            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if(!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ugyldig værdi, vælg et tal mellem 2 og 4");
                }
            }
             Console.WriteLine("");
        }
       

        private void CreatePlayers()
        {
            this.players = new Player[this.numberOfPlayers];
            for (int i = 0; i < this.numberOfPlayers; i++)
            {
                Console.WriteLine();
                Console.Write("Hvad hedder spiller {0}: ", (i + 1));
                string name = Console.ReadLine();
                Token[] tkns = AssingTokens(i);
                players[i] = new Player((i+1), name, tkns);

                
                
            }
        }
        private Token[] AssingTokens(int colorIndex)
        {
            Token[] tokens = new Token[4];
            for(int i =0; i<=3; i++)
            {
                switch(colorIndex)
                {
                    case 0:
                        tokens[i] =new Token((i+1), GameColor.Blu);
                        break;
                    case 1:
                        tokens[i] =new Token((i+1), GameColor.Green);
                        break;
                    case 2:
                        tokens[i] =new Token((i+1), GameColor.Red);
                        break;
                    case 3:
                        tokens[i] =new Token((i+1), GameColor.Yellow);
                        break;
                }

            }
            return tokens;
        }

        private void ShowPlayers()
        {
            Console.WriteLine();
            Console.WriteLine("Okay, her er dine spillere:");
            foreach (Player pl in this.players)
            {
                Console.WriteLine(pl.GetDescription());
            }
           Console.WriteLine("");
        }
        private void TakeTurns()
        {
            while(this. state == GameState.Inplay)
            {
                Player myTurn =  players[(playerTurn-1)];
                Console.WriteLine(myTurn.GetName + "'s tur");
                Console.WriteLine("det er " + myTurn.GetDescription() + " tur");
                do
                {
                    Console.WriteLine("klar til at (K)aste");
                }
                while(Console.ReadKey().KeyChar != 'k');
                Console.WriteLine("Du slog " + dice.ThrowDice().ToString());
                Console.WriteLine("");
                ShowTurnOptions(myTurn.GetTokens());
                break;
            }
        }

            
        



        public void ShowTurnOptions(Token[] tokens)
		{
			int choice = 0;

            Console.WriteLine("Her er dine brikker:");
			foreach (Token tk in tokens)
			{

                Console.Write("Brik #" + tk.GetTokenId() + ": er placeret: " + tk.GetState());

                switch(tk.GetState()){
                    case TokenState.Home:
                        if(dice.GetValue() == 6){
                            Console.Write(" <- Kan spilles");
                            choice++;
                        } else {
                            Console.Write(" <- Kan IKKE spilles");
                        }
                        break;
                    case TokenState.InPlay:
                        Console.Write(" <- Kan spilles");
                        choice++;
						break;
                    case TokenState.Safe:
                        Console.Write(" <- Kan spilles");
                        choice++;
						break;
                }
                Console.WriteLine("");
			}
            Console.WriteLine("");
            Console.WriteLine("Du har "+choice.ToString()+" muligheder i denne tur.");

            // No options, change turn
            if(choice == 0){
                this.ChangeTurn();
            } else {
                Console.WriteLine("Vælg den #brik du vil spille?");

            }
		}
		
        private void ChangeTurn()
		{
            Console.WriteLine("");
            if (playerTurn == numberOfPlayers){
                playerTurn = 1;
            } else {
                playerTurn++;
            }

            Console.Write("Skifter spiller om: ");
			for (int i = 3; i > 0; i--)
			{
                Console.Write(" "+i.ToString()+" ");
			}

            pause(1000);
            TakeTurns();
	}
    }

}
