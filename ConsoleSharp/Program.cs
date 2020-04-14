using ConsoleSharp.Module;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleSharp
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            // //输入用户名
            // Console.WriteLine("请输入您的名字");
            // string userName = Console.ReadLine();
            // Console.WriteLine("您的名字是：\"{0} \"", userName);
            //
            // Player user = new Player(userName, BasicPlayer.gender.Male, 200, 200);
            // Player arno = new Player("Arno", BasicPlayer.gender.Male);
            //
            // Game.Fight(user, arno);
            // while (true)
            // {
            //     var exp = Console.ReadLine();
            //
            //     var tree = new ExpressionTree(exp);
            //     foreach (var node in tree)
            //     {
            //         Console.Write(node.ToString());
            //     }
            //     Console.WriteLine("");
            //     Console.WriteLine("结果：");
            //     Console.WriteLine(tree.Result);
            // }

            int[] arr = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11};
            var count = arr.Count(x => x > 5);
            Console.WriteLine(count);
            Console.ReadKey();


        }
    }
}