using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TicTacToeConsole
{
    class GameArea
    {      
        public GameArea()
        {
        }

        public int Width { get; } = 23;

        public int Height { get; } = 11;

        public Point Location { get; } = new Point(12, 1);

        public ConsoleColor BorderColor { get; } = ConsoleColor.White;

        public string[] GameMoves { get; set; } = new string[9];

        public string[] GameAreaArray { get; set; } = new string[31];

        public bool player1Turn { get; set; } = true;

        public int playerTurnCount { get; set; } = 0;

        public void Draw()
        {
            string offset = "";
            string topBottomElement = "";
            string emptyElement = "";
            string emptyStr;
            string startElement;
            string betweenElement;
            string endElement;
 
            for (int i = 0; i < Location.X; i++)
                offset += " ";
            for (int i = 0; i < 7; i++)
            {
                topBottomElement += "\u2550";
                emptyElement += " ";
            }

            startElement = offset + "\u2551" + " ";
            emptyStr = offset + "\u2551" + emptyElement + "\u2551" + emptyElement + "\u2551" + emptyElement + "\u2551" + "\n";
            betweenElement = " " + "\u2551" + " ";
            endElement = " " + "\u2551" + "\n";

            GameAreaArray[0] = "\u2554" + topBottomElement + "\u2566" + topBottomElement + "\u2566" + topBottomElement + "\u2557" + "\n";
            GameAreaArray[1] = emptyStr;
            GameAreaArray[2] = startElement;          
            GameAreaArray[3] = GameMoves[0];
            GameAreaArray[4] = betweenElement;
            GameAreaArray[5] = GameMoves[1];
            GameAreaArray[6] = betweenElement;
            GameAreaArray[7] = GameMoves[2];
            GameAreaArray[8] = endElement;
            GameAreaArray[9] = emptyStr;
            GameAreaArray[10] = offset + "\u2560" + topBottomElement + "\u256C" + topBottomElement + "\u256C" + topBottomElement + "\u2563" + "\n";
            GameAreaArray[11] = emptyStr;
            GameAreaArray[12] = startElement;
            GameAreaArray[13] = GameMoves[3];
            GameAreaArray[14] = betweenElement;
            GameAreaArray[15] = GameMoves[4];
            GameAreaArray[16] = betweenElement;
            GameAreaArray[17] = GameMoves[5];
            GameAreaArray[18] = endElement;
            GameAreaArray[19] = emptyStr;
            GameAreaArray[20] = offset + "\u2560" + topBottomElement + "\u256C" + topBottomElement + "\u256C" + topBottomElement + "\u2563" + "\n";
            GameAreaArray[21] = emptyStr;
            GameAreaArray[22] = startElement;
            GameAreaArray[23] = GameMoves[6];
            GameAreaArray[24] = betweenElement;
            GameAreaArray[25] = GameMoves[7];
            GameAreaArray[26] = betweenElement;
            GameAreaArray[27] = GameMoves[8];
            GameAreaArray[28] = endElement;
            GameAreaArray[29] = emptyStr;
            GameAreaArray[30] = offset + "\u255A" + topBottomElement + "\u2569" + topBottomElement + "\u2569" + topBottomElement + "\u255D" + "\n";
           
            Console.ForegroundColor = BorderColor;
            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;

            RedrawArea(GameAreaArray);
            Console.ResetColor();
        }
       
        public void InitializeGameMoves()
        {
            for (int i = 0; i < 9; i++)
            {
                GameMoves[i] = "( " + Convert.ToString(i + 1) + " )";
            }
        }

        public void RedrawArea(string[] GameAreaArr)
        {
            for (int i = 0; i < GameAreaArr.Length; i++)
            {
                if (GameAreaArr[i] == "  X  " || GameAreaArr[i] == "X WIN")
                {
                    Console.ForegroundColor = ConsoleColor.Red;                
                }
                else if (GameAreaArr[i] == "  0  " || GameAreaArr[i] == "0 WIN")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }               
                Console.Write(GameAreaArr[i]);
                Console.ForegroundColor = BorderColor;
            }            
        }
    }
}
