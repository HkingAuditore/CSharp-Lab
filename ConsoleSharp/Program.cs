using System;
using ConsoleSharp.Process;

namespace ConsoleSharp
{

    class Program
    {
        static void Main(string[] args)
        {
            Player ezio  = new Player("Ezio",true,200,200);
            Player arno  = new Player("Arno",true);

            Game.Fight(ezio, arno);
        }
    }
}
