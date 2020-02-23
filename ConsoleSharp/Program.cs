using ConsoleSharp.Module;
using System;

namespace ConsoleSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Player ezio = new Player("Ezio", true, 200, 200);
            Player arno = new Player("Arno", true);

            Game.Fight(ezio, arno);
            Console.ReadLine();
        }
    }
}