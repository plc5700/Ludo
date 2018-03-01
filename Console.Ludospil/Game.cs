
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    public enum GameColor {Yellow, Green, Blu, Red, white};
    public enum GameState {Inplay, Finished};

    public class Game
    {
        private GameState state;
        private int numberOfPlayers;
        private int chooseToken;
        private Player[] players;
        private Field[] field;
        private int playerTurn = 1;
        private Dice dice = new Dice();
        private int ct = 0;
        int choice = 0;

        public Game()
        {
            Console.WriteLine("hej og Velkommen til mit Ludo spil");
            SetNumberOfPlayers();
            CreatePlayers();
            CreateField();
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
        public void CreateField()
        {
            this.field = new Field[77];
            for (int i = 0; i <= 76; i++)
            {
                switch (i)
                {
                    case 0:
                        field[i] = new Field(i, GameColor.white, FieldType.Home);
                        break;
                    //case 1:
                    //    field[i] = new Field(i, GameColor.Red, FieldType.Safe);
                    //    break;
                    //case 14:
                    //    field[i] = new Field(i, GameColor.Blu, FieldType.Safe);
                    //    break;
                    //case 27:
                    //    field[i] = new Field(i, GameColor.Yellow, FieldType.Safe);
                    //    break;
                    //case 40:
                    //    field[i] = new Field(i, GameColor.Green, FieldType.Safe);
                    //    break;
                    case 1: case 53: case 54: case 55: case 56: case 57:
                        field[i] = new Field(i, GameColor.Red, FieldType.Safe);
                        break;
                    case 14: case 59: case 60: case 61: case 62: case 63:
                        field[i] = new Field(i, GameColor.Blu, FieldType.Safe);
                        break;
                    case 27: case 65: case 66: case 67: case 68: case 69:
                        field[i] = new Field(i, GameColor.Yellow, FieldType.Safe);
                        break;
                    case 40: case 71: case 72: case 73: case 74: case 75:
                        field[i] = new Field(i, GameColor.Green, FieldType.Safe);
                        break;
                    case 58:
                        field[i] = new Field(i, GameColor.Red, FieldType.Finish);
                        break;
                    case 64:
                        field[i] = new Field(i, GameColor.Blu, FieldType.Finish);
                        break;
                    case 70:
                        field[i] = new Field(i, GameColor.Yellow, FieldType.Finish);
                        break;
                    case 76:
                        field[i] = new Field(i, GameColor.Green, FieldType.Finish);
                        break;
                    default:
                        field[i] = new Field(i, GameColor.white, FieldType.InPlay);
                        break;

                }
                
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
            //while(this.state == GameState.Inplay)
            //{

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
                //break;
            //}
        }

            
        



        public void ShowTurnOptions(Token[] tokens)
		{
			//int choice = 0;
            choice = 0;

            Console.WriteLine("Her er dine brikker:");
			foreach (Token tk in tokens)
			{

                Console.Write("Brik #" + tk.GetTokenId() + ": er placeret: " + field[tk.TokenLocation].GetFieldType());

                switch(field[tk.TokenLocation].GetFieldType())
                {
                    case FieldType.Home:
                        if(dice.GetValue() == 6)
                        {
                            Console.Write(" <- Kan spilles");
                            choice++;
                        } else {
                            Console.Write(" <- Kan IKKE spilles");
                        }
                        break;
                    case FieldType.InPlay:
                        Console.Write(" <- Kan spilles");
                        choice++;
						break;
                    case FieldType.Safe:
                        Console.Write(" <- Kan spilles");
                        choice++;
						break;
                    case FieldType.Finish:
                        Console.Write("er i mål");
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
            //TjekFortoken;
            players[playerTurn - 1].Movetoken(dice.GetValue(), chooseToken - 1, playerTurn - 1, players[playerTurn-1].TokenLocation(chooseToken-1) );
            chooseToken = 0;
            ChangeTurn();

        }
        public void TjekFortoken(int id, int ply, int fld, int mv)
        {
          
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
            else if(field[players[playerTurn - 1].TokenLocation(0)].GetFieldType() == FieldType.Home && field[players[playerTurn - 1].TokenLocation(1)].GetFieldType() == FieldType.Home && field[players[playerTurn - 1].TokenLocation(2)].GetFieldType() == FieldType.Home && field[players[playerTurn - 1].TokenLocation(3)].GetFieldType() == FieldType.Home && ct < 2 )
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
