using System;

namespace TicTacToeConsole
{
    class Program
    {        
        static void Main(string[] args)
        {
            GameArea area = new GameArea(20, 10, new System.Drawing.Point(12,1), ConsoleColor.DarkRed);
            area.Draw();
            //Console.ReadLine();


        }    
    }
}       

