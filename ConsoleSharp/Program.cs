using ConsoleSharp.Module;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleSharp
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            //输入用户名
            // Console.WriteLine("请输入您的名字");
            // string userName = Console.ReadLine();
            // Console.WriteLine("您的名字是：\"{0} \"", userName);
            //
            // Player user = new Player(userName, BasicPlayer.gender.Male, 200, 200);
            // Player arno = new Player("Arno", BasicPlayer.gender.Male);
            //
            // Game.Fight(user, arno);
            for (int i = 0; i < 20; i++)
            {
                Random luck = new Random();
                float minRate = 0.6f;
                double actualRate = luck.NextDouble();
                double fixedRate = actualRate;
                // E(actualRate) = 0.5
                if (fixedRate < minRate) actualRate = actualRate / minRate * (1 - minRate) + minRate;
                Console.WriteLine(actualRate + " : "+ fixedRate);
            }
            
        }
    }
}