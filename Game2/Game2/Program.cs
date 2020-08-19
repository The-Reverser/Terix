using System;
using System.Collections;

namespace Game2
{
    class Program
    {
      
        static void Main(string[] args)
        {
           
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;//鼠标不可见
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            /* Console.WriteLine("██");
             Console.WriteLine("██");
             Console.WriteLine("▓▓");*/
            /*  BaseGround one = new BaseGround(20,30);
              one.InitBackground();
              one.Print();*/



            GameProcess game = new GameProcess();
            game.StartGame();

        }
    }
}
