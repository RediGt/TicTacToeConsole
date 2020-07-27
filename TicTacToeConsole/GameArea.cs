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
            string s = "\u2554";  //"╔";
            string space = "";
            string temp = "";
            string horizontalLine = "\u2560";
            string raw1 = "\u2551";
            string raw2 = "\u2551";
            string raw3 = "\u2551";
            for (int i = 0; i < Width; i++)
            {
                if (i == 7 || i == 15)
                {
                    s += "\u2566";
                    space += "\u2551";
                    horizontalLine += "\u256C";
                    raw1 += "\u2551";
                    raw2 += "\u2551";
                    raw3 += "\u2551";
                }
                else if (i == 3)
                {
                    raw1 += GameMoves[0];
                    raw2 += GameMoves[3];
                    raw3 += GameMoves[6];
                    s += "\u2550";  //"═";
                    space += " ";
                    horizontalLine += "\u2550";
                }
                else if (i == 11)
                {
                    raw1 += GameMoves[1];
                    raw2 += GameMoves[4];
                    raw3 += GameMoves[7];
                    s += "\u2550";  //"═";
                    space += " ";
                    horizontalLine += "\u2550";
                }
                else if (i == 19)
                {
                    raw1 += GameMoves[2];
                    raw2 += GameMoves[5];
                    raw3 += GameMoves[8];
                    s += "\u2550";  //"═";
                    space += " ";
                    horizontalLine += "\u2550";
                }
                else 
                {
                    s += "\u2550";  //"═";
                    space += " ";
                    horizontalLine += "\u2550";
                    raw1 += " ";
                    raw2 += " ";
                    raw3 += " ";
                } 
            }
            horizontalLine += "\u2563";
            raw1 += "\u2551";
            raw2 += "\u2551";
            raw3 += "\u2551";
            s += "\u2557" + "\n";  //"╗"

            for (int j = 0; j < Location.X; j++)
                temp += " ";
           
            for (int i = 0; i < Height; i++)
            {                              
                if (i == 3 || i == 7)
                {
                    s += temp + horizontalLine + "\n";
                }
                else if (i == 1)
                    s += temp + raw1 + "\n";
                else if (i == 5)
                    s += temp + raw2 + "\n";
                else if (i == 9)
                    s += temp + raw3 + "\n";
                else
                {
                    s += temp + "\u2551" + space + "\u2551" + "\n";
                }
            }

            s += temp + "\u255A"; // "╚";
            for (int i = 0; i < Width; i++)
            {
                if (i == 7 || i == 15)
                    s += "\u2569";
                else
                    s += "\u2550";  //"═";
            }

            s += "\u255D" + "\n"; //"╝"

            Console.ForegroundColor = BorderColor;
            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;
            Console.Write(s);
            Console.ResetColor();
        }

        public void InitializeGameMoves()
        {
            for (int i = 0; i < 9; i++)
            {
                GameMoves[i] = Convert.ToString(i + 1);
            }
        }
    }
}
