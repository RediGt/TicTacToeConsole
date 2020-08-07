using System;
using System.Media;

namespace TicTacToeConsole
{
    class Program
    {
        static bool gameEnded;
        static int turnCount;

        static void Main(string[] args)
        {                                 
            GameArea area = new GameArea();
            area.InitializeGameMoves();

            string userChoice;
            area.Draw();

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
            area.player1Turn = true;
            gameEnded = false;
            turnCount = 0;
        }

        static string UserAction()
        {
            Console.WriteLine("\nMake your choice:" +
                    "\n'any key' - Continue" +
                    "\n'q' - Quit the program");
            return Console.ReadLine();
        }

        static void PlayerMove(GameArea area)
        {
            int cellIndex;
            if (area.player1Turn)
            {
                Console.WriteLine("Payer \"X\" move.");
                cellIndex = InputCheckOfCellNo(area);
                area.GameMoves[cellIndex - 1] = "  X  ";
                area.player1Turn = false;
                PlaySound("ClickSound.wav");
            }
            else
            {
                Console.WriteLine("Payer \"0\" move.");               
                cellIndex = InputCheckOfCellNo(area);
                area.GameMoves[cellIndex - 1] = "  0  ";
                area.player1Turn = true;
                PlaySound("ClickSound2.wav");
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

            do
            {
                Console.Write("Insert No of cell, \"s\" to save or \"l\" to load: ");
                userInput = Console.ReadLine().ToUpper();
                                
                switch(userInput)
                {
                    case "S":
                        JsonIO.SaveToFile(area);
                        Console.WriteLine("Game saved");
                        break;
                    case "L":
                        area = JsonIO.LoadFromFile();
                        area.Draw();
                        PlayerMove(area);
                        break;
                    default:
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
                        else if ("( " + userInput + " )" != area.GameMoves[cell - 1])
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
                        break;
                }
                
            }
            while (!correctInput);

            return cell;
        }

        static void PlaySound(string soundName)
        {
            var soundLocation = @"G:\C#\TicTacToeConsole\Sound\";
            SoundPlayer snd = new System.Media.SoundPlayer
            {
                SoundLocation = soundLocation + soundName,
            };
            snd.Play();
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
                if (area.GameMoves[0] == "  X  ")
                {
                    area.GameMoves[0] = "X WIN";
                    area.GameMoves[1] = "X WIN";
                    area.GameMoves[2] = "X WIN";
                }
                if (area.GameMoves[0] == "  0  ")
                {
                    area.GameMoves[0] = "0 WIN";
                    area.GameMoves[1] = "0 WIN";
                    area.GameMoves[2] = "0 WIN";
                }
                gameEnded = true;
            }
            
            if (area.GameMoves[3] == area.GameMoves[4] && area.GameMoves[3] == area.GameMoves[5])
            {
                if (area.GameMoves[3] == "  X  ")
                {
                    area.GameMoves[3] = "X WIN";
                    area.GameMoves[4] = "X WIN";
                    area.GameMoves[5] = "X WIN";
                }
                if (area.GameMoves[3] == "  0  ")
                {
                    area.GameMoves[3] = "0 WIN";
                    area.GameMoves[4] = "0 WIN";
                    area.GameMoves[5] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[6] == area.GameMoves[7] && area.GameMoves[6] == area.GameMoves[8])
            {
                if (area.GameMoves[6] == "  X  ")
                {
                    area.GameMoves[6] = "X WIN";
                    area.GameMoves[7] = "X WIN";
                    area.GameMoves[8] = "X WIN";
                }
                if (area.GameMoves[6] == "  0  ")
                {
                    area.GameMoves[6] = "0 WIN";
                    area.GameMoves[7] = "0 WIN";
                    area.GameMoves[8] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[0] == area.GameMoves[3] && area.GameMoves[0] == area.GameMoves[6])
            {
                if (area.GameMoves[0] == "  X  ")
                {
                    area.GameMoves[0] = "X WIN";
                    area.GameMoves[3] = "X WIN";
                    area.GameMoves[6] = "X WIN";
                }
                if (area.GameMoves[0] == "  0  ")
                {
                    area.GameMoves[0] = "0 WIN";
                    area.GameMoves[3] = "0 WIN";
                    area.GameMoves[6] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[1] == area.GameMoves[4] && area.GameMoves[1] == area.GameMoves[7])
            {
                if (area.GameMoves[1] == "  X  ")
                {
                    area.GameMoves[1] = "X WIN";
                    area.GameMoves[4] = "X WIN";
                    area.GameMoves[7] = "X WIN";
                }
                if (area.GameMoves[1] == "  0  ")
                {
                    area.GameMoves[1] = "0 WIN";
                    area.GameMoves[4] = "0 WIN";
                    area.GameMoves[7] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[2] == area.GameMoves[5] && area.GameMoves[2] == area.GameMoves[8])
            {
                if (area.GameMoves[2] == "  X  ")
                {
                    area.GameMoves[2] = "X WIN";
                    area.GameMoves[5] = "X WIN";
                    area.GameMoves[8] = "X WIN";
                }
                if (area.GameMoves[2] == "  0  ")
                {
                    area.GameMoves[2] = "0 WIN";
                    area.GameMoves[5] = "0 WIN";
                    area.GameMoves[8] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[0] == area.GameMoves[4] && area.GameMoves[0] == area.GameMoves[8])
            {
                if (area.GameMoves[0] == "  X  ")
                {
                    area.GameMoves[0] = "X WIN";
                    area.GameMoves[4] = "X WIN";
                    area.GameMoves[8] = "X WIN";
                }
                if (area.GameMoves[0] == "  0  ")
                {
                    area.GameMoves[0] = "0 WIN";
                    area.GameMoves[4] = "0 WIN";
                    area.GameMoves[8] = "0 WIN";
                }
                gameEnded = true;
            }

            if (area.GameMoves[2] == area.GameMoves[4] && area.GameMoves[2] == area.GameMoves[6])
            {
                if (area.GameMoves[2] == "  X  ")
                {
                    area.GameMoves[2] = "X WIN";
                    area.GameMoves[4] = "X WIN";
                    area.GameMoves[6] = "X WIN";
                }
                if (area.GameMoves[2] == "  0  ")
                {
                    area.GameMoves[2] = "0 WIN";
                    area.GameMoves[4] = "0 WIN";
                    area.GameMoves[6] = "0 WIN";
                }
                gameEnded = true;
            }
            
            if (gameEnded && area.player1Turn)
            {
                Console.WriteLine("Game ended! Player 0 winns!");
                PlaySound("WinnerSound.wav");
                area.Draw();
            }               
            else if (gameEnded)
            {
                Console.WriteLine("Game ended! Player X winns!");
                PlaySound("WinnerSound.wav");
                area.Draw();
            }
        }
    }
}       

