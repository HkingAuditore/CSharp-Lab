using ConsoleSharp.Module;
using System;

namespace ConsoleSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("请输入您的名字");
            string userName = Console.ReadLine();
            Player user = new Player(userName, true, 200, 200);
            Player arno = new Player("Arno", true);

            Game.Fight(user, arno);
            Console.ReadLine();
        }
    }
}