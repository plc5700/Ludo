
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
        private int numberOfPlayers;
        private int chooseToken;
        private Player[] players;
        private int playerTurn = 1;
        private Dice dice = new Dice();
        private int ct = 0;
        int choice = 0;

        public Game()
        {
            Console.WriteLine("hej og Velkommen til mit Ludo spil");
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            state = GameState.Inplay;
            Console.WriteLine("klar til at spille (tryk vilkensomhelst knap)");
            Console.ReadKey();
            Clear();
            TakeTurns();
        }

        private void Clear()
        {
            Console.Clear();
            Console.WriteLine("__________Ludo__________");
            Console.WriteLine();
        }

        private void Pause(int dl)
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
                        tokens[i] =new Token((i+1), GameColor.Red, 0);
                        break;
                    case 1:
                        tokens[i] =new Token((i+1), GameColor.Blu, 0);
                        break;
                    case 2:
                        tokens[i] =new Token((i+1), GameColor.Yellow, 0);
                        break;
                    case 3:
                        tokens[i] =new Token((i+1), GameColor.Green, 0);
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
			//int choice = 0;
            choice = 0;

            Console.WriteLine("Her er dine brikker:");
			foreach (Token tk in tokens)
			{

                Console.Write("Brik #" + tk.GetTokenId() + ": er placeret: " + tk.GetState());

                switch(tk.GetState()){
                    case TokenState.Home:
                        if(dice.GetValue() == 6)
                        {
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
            if(choice == 0)
            {
                this.ChangeTurn();
            }
            else
            {
                this.MoveToken();
            }
        }

        private void MoveToken()
        {
            Console.WriteLine("Vælg den #brik du vil spille?");
            while (chooseToken < 1 || chooseToken > 4)
            {
                //Console.ReadKey();
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.chooseToken))
                {
                    Console.WriteLine();
                    Console.WriteLine("Ugyldig værdi, vælg et tal mellem 1 og 4");
                }
            }


            //players[playerTurn].TokenLocation
            players[playerTurn - 1].Movetoken(dice.GetValue(), chooseToken - 1);
            ChangeTurn();

        }
    
		
        private void ChangeTurn()
		{
            
            Console.WriteLine("");
            if(dice.GetValue() == 6)
			{
                Console.Write("det er nu ");
                Pause(1000);
                TakeTurns();
            }
            //choice == 0 && ct > 3)
            else if(players[playerTurn - 1].GetStat(0)==TokenState.Home && players[playerTurn - 1].GetStat(1)==TokenState.Home && players[playerTurn - 1].GetStat(2)==TokenState.Home && players[playerTurn - 1].GetStat(3)==TokenState.Home && ct < 2 )
            {
                ct++;
                Console.Write("det er nu ");
                Pause(1000);
                TakeTurns();
            }
            else
            {
                ct = 0;
                NextPlayer();
            }
	    }
        private void NextPlayer()
        {
            Console.WriteLine("tyrke en tast for næste spille");
            Console.ReadKey();
            Clear();
            Console.WriteLine("");
            if (playerTurn == numberOfPlayers)
            {
                playerTurn = 1;
            }
            else
            {
                playerTurn++;
            }
            Console.Write("det er nu ");
            Pause(1000);
            TakeTurns();
        }
    }

}
