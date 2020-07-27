using System;

namespace TicTacToeConsole
{
    class Program
    {
        static bool player1Turn;
        static bool gameEnded;

        static void Main(string[] args)
        {                                 
            GameArea area = new GameArea();
            NewGame(area);         
            //area.GameMoves[5] = Console.ReadLine();
            //area.Draw();
            //area.GameMoves[2] = Console.ReadLine();
            //area.Draw();
            //NewGame();
            //while()


        }

        static void NewGame(GameArea area)
        {
            area.InitializeGameMoves();
            area.Draw();
            player1Turn = true;
            gameEnded = false;
        }
    }
}       

