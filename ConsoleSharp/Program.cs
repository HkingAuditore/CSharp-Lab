using ConsoleSharp.Module;
using System;

namespace ConsoleSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //输入用户名
            Console.WriteLine("请输入您的名字");
            string userName = Console.ReadLine();
            Console.WriteLine("您的名字是：\"{0} \"",userName);

            //模拟战斗
            /**
             *
             * 这里用了在BasePlayer基类上派生的Player类
             *
             *
             *
             */
            Player user = new Player(userName, BasicPlayer.gender.Male, 200, 200);
            Player arno = new Player("Arno", BasicPlayer.gender.Male);

            Game.Fight(user, arno);
            Console.ReadLine();
        }
    }
}