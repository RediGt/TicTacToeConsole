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

        public void Draw()
        {
            string offset = "";
            string topBottomElement = "";
            string emptyElement = "";
            string emptyStr;
            string startElement;
            string betweenElement;
            string endElement;
            string[] drawArea = new string[31];

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

            drawArea[0] = "\u2554" + topBottomElement + "\u2566" + topBottomElement + "\u2566" + topBottomElement + "\u2557" + "\n";
            drawArea[1] = emptyStr;
            drawArea[2] = startElement;          
            drawArea[3] = GameMoves[0];
            drawArea[4] = betweenElement;
            drawArea[5] = GameMoves[1];
            drawArea[6] = betweenElement;
            drawArea[7] = GameMoves[2];
            drawArea[8] = endElement;
            drawArea[9] = emptyStr;
            drawArea[10] = offset + "\u2560" + topBottomElement + "\u256C" + topBottomElement + "\u256C" + topBottomElement + "\u2563" + "\n";
            drawArea[11] = emptyStr;
            drawArea[12] = startElement;
            drawArea[13] = GameMoves[3];
            drawArea[14] = betweenElement;
            drawArea[15] = GameMoves[4];
            drawArea[16] = betweenElement;
            drawArea[17] = GameMoves[5];
            drawArea[18] = endElement;
            drawArea[19] = emptyStr;
            drawArea[20] = offset + "\u2560" + topBottomElement + "\u256C" + topBottomElement + "\u256C" + topBottomElement + "\u2563" + "\n";
            drawArea[21] = emptyStr;
            drawArea[22] = startElement;
            drawArea[23] = GameMoves[6];
            drawArea[24] = betweenElement;
            drawArea[25] = GameMoves[7];
            drawArea[26] = betweenElement;
            drawArea[27] = GameMoves[8];
            drawArea[28] = endElement;
            drawArea[29] = emptyStr;
            drawArea[30] = offset + "\u255A" + topBottomElement + "\u2569" + topBottomElement + "\u2569" + topBottomElement + "\u255D" + "\n";
           
            Console.ForegroundColor = BorderColor;
            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;

            RedrawArea(drawArea);
            Console.ResetColor();
        }
       
        public void InitializeGameMoves()
        {
            for (int i = 0; i < 9; i++)
            {
                GameMoves[i] = "( " + Convert.ToString(i + 1) + " )";
            }
        }

        public void RedrawArea(string[] drawArea)
        {
            for (int i = 0; i < drawArea.Length; i++)
            {
                if (drawArea[i] == "  X  ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;                
                }
                else if (drawArea[i] == "  0  ")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }               
                Console.Write(drawArea[i]);
                Console.ForegroundColor = BorderColor;
            }            
        }
    }
}
