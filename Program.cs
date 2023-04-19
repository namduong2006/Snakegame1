using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame2
{
    internal class Program
    {
        public static void Map(int hang, int cot)
        {
            for (int i = 0; i < cot; i++)
            {
                for (int j = 0; j < hang; j++)
                {
                    if (i == 0 || i == cot - 1)
                    {
                        Write(i, j, "*");
                    }
                    if (j == 0 || j == hang - 1)
                    {
                        Write(i, j, "=");
                    }
                }
            }
        }
        public static void Snake(int[] Xsnake, int[] Ysnake)
        {
            for (int i = 0; i < Xsnake.Length; i++)
            {
                if (i == 0)
                {
                    Write(Xsnake[i], Ysnake[i], "=");
                }               
                else Write(Xsnake[i], Ysnake[i], "O");
            }
        }
        public static void Food(int Xfood, int Yfood)
        {
            Write(Xfood, Yfood, "+");
        }
        static void MoveSnake(int[] Xsnake, int[] Ysnake)
        {
            for (int i = Xsnake.Length - 1; i > 0; i--)
            {
                Xsnake[i] = Xsnake[i - 1];
                Ysnake[i] = Ysnake[i - 1];               
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                Ysnake[0]--;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                Ysnake[0]++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Xsnake[0]--;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                Xsnake[0]++;
            }
        }
        public static void Write(int X, int Y, string content)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(content);
        }
        static void Main(string[] args)
        {            
            int hang = 20;
            int cot = 40;            
            Random random = new Random();            
            int[] Xsnake = { 3 };
            int[] Ysnake = { 3 };            
            bool gameOver = false;
            int Xfood = 8;
            int Yfood = 8;
            while (!gameOver)
            {
                Map(hang, cot);
                Snake(Xsnake, Ysnake);
                Food(Xfood, Yfood);
                MoveSnake(Xsnake, Ysnake);
                if (Xsnake[0] == Xfood && Ysnake[0] == Yfood)
                {
                    Xfood = random.Next(1, cot - 2);
                    Yfood = random.Next(1, hang - 2);
                    Array.Resize(ref Xsnake, Xsnake.Length + 1);
                    Array.Resize(ref Ysnake, Ysnake.Length + 1);
                }
                if (Xsnake[0]<1 || Xsnake[0] == cot - 1 || Ysnake[0]<1 || Ysnake[0]==hang-1)
                    gameOver = true;
                Console.Clear();
                Map(hang, cot);
                Snake(Xsnake, Ysnake);
            }   
            if (gameOver = true)
            {
                Write(cot / 2, hang / 2, "GAME OVER");
                Console.ReadLine();
            }            
        }
    }
}


