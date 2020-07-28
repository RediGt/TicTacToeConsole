using System;

namespace TicTacToeConsole
{
    class Program
    {
        static bool player1Turn;
        static bool gameEnded;
        static int turnCount;

        static void Main(string[] args)
        {                                 
            GameArea area = new GameArea();

            string userChoice;
            do
            {
                NewGame(area);
                for ( ; ; )
                {
                    if (gameEnded)
                        break;
                    PlayerMove(area);
                }
                    
                userChoice = UserAction();
            }
            while (userChoice != "q" && userChoice != "Q");
        }

        static void NewGame(GameArea area)
        {
            area.InitializeGameMoves();
            Console.Clear();
            area.Draw();
            player1Turn = true;
            gameEnded = false;
            turnCount = 0;
        }

        static void PlayerMove(GameArea area)
        {
            int cellIndex;
            if (player1Turn)
            {
                Console.WriteLine("Payer \"X\" move.");
                cellIndex = InputCheckOfCellNo(area);
                area.GameMoves[cellIndex - 1] = "X";
                player1Turn = false;
            }
            else
            {
                Console.WriteLine("Payer \"0\" move.");
                cellIndex = InputCheckOfCellNo(area);
                area.GameMoves[cellIndex - 1] = "0";
                player1Turn = true;
            }

            turnCount++;
            Console.Clear();
            area.Draw();

            CheckForWin(area);
            CheckForDraw();
        }

        static int InputCheckOfCellNo(GameArea area)
        {
            string userInput;
            int cell = 0;
            bool correctInput = false;

            Console.Write("Insert No of cell: ");
            do
            {
                userInput = Console.ReadLine();
                                
                try
                {
                    cell = Convert.ToInt32(userInput);
                }
                catch
                {
                    correctInput = false;
                    Console.WriteLine("Incorrect input!");
                    Console.Write("Input No of unoccupied cell one more: ");
                    continue;
                }                           

                if (cell < 1 || cell > 9)
                {
                    correctInput = false;
                    Console.WriteLine("Incorrect input!");
                    Console.Write("Input No of unoccupied cell one more: ");
                    continue;
                }
                else if (userInput != area.GameMoves[cell - 1])
                {
                    correctInput = false;
                    Console.WriteLine("Cell is occupied!");
                    Console.Write("Input No of unoccupied cell one more: ");
                    continue;
                }
                else
                {
                    correctInput = true;                   
                }
            }
            while (!correctInput);

            return cell;
        }
       
        static void CheckForDraw()
        {
            if (turnCount == 9 && !gameEnded)
            {
                Console.WriteLine("Game ended!");
                Console.WriteLine("DRAW!");
                gameEnded = true;
            }
        }

        static void CheckForWin(GameArea area)
        {
            if (area.GameMoves[0] == area.GameMoves[1] && area.GameMoves[0] == area.GameMoves[2])
            {
                gameEnded = true;
            }
            
            if (area.GameMoves[3] == area.GameMoves[4] && area.GameMoves[3] == area.GameMoves[5])
            {
                gameEnded = true;
            }

            if (area.GameMoves[6] == area.GameMoves[7] && area.GameMoves[6] == area.GameMoves[8])
            {
                gameEnded = true;
            }

            if (area.GameMoves[0] == area.GameMoves[3] && area.GameMoves[0] == area.GameMoves[6])
            {
                gameEnded = true;
            }

            if (area.GameMoves[1] == area.GameMoves[4] && area.GameMoves[1] == area.GameMoves[7])
            {
                gameEnded = true;
            }

            if (area.GameMoves[2] == area.GameMoves[5] && area.GameMoves[2] == area.GameMoves[8])
            {
                gameEnded = true;
            }

            if (area.GameMoves[0] == area.GameMoves[4] && area.GameMoves[0] == area.GameMoves[8])
            {
                gameEnded = true;
            }

            if (area.GameMoves[2] == area.GameMoves[4] && area.GameMoves[2] == area.GameMoves[6])
            {
                gameEnded = true;
            }
            
            if (gameEnded && player1Turn)
                Console.WriteLine("Game ended! Player 0 winns!");
            else if (gameEnded)
                Console.WriteLine("Game ended! Player X winns!");
        }

        static string UserAction()
        {
            Console.WriteLine("\nMake your choice:" +
                    "\n'any key' - Continue" +
                    "\n'q' - Quit the program");
            return Console.ReadLine();
        }
    }
}       

