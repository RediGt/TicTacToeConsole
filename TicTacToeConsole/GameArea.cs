using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TicTacToeConsole
{
    class GameArea
    {      
        public GameArea(int width, int height, Point location, ConsoleColor borderColor)
        {
            this.Width = width;
            this.Height = height;
            this.Location  = location;
            this.BorderColor = borderColor;          
        }

        public int Width { get; }

        public int Height { get; }

        public Point Location { get; }    
      
        public ConsoleColor BorderColor { get; }        

        public void Draw()
        {
            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += " ";
                s += "═";
            }

            for (int j = 0; j < Location.X; j++)
                temp += " ";

            s += "╗" + "\n";

            for (int i = 0; i < Height; i++)
                s += temp + "║" + space + "║" + "\n";

            s += temp + "╚";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╝" + "\n";

            Console.ForegroundColor = BorderColor;
            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}
