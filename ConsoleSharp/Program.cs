using System;

namespace ConsoleSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BasicPlayer ezio = new BasicPlayer("Ezio", true, 200, 200);
            BasicPlayer arno = new BasicPlayer("Arno", true);

            BasicGame.Fight(ezio, arno);
            Console.ReadLine();
        }
    }
}