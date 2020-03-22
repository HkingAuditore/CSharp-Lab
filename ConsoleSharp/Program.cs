using ConsoleSharp.Module;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleSharp
{
    interface IYell
    {
        void Yell();
    }

    class Cat:IYell
    {
        public void Yell()
        {
            Console.WriteLine("Mew");
        }
    }

    class Dog:IYell
    {
        public void Yell()
        {
            Console.WriteLine("Bowwow");
        }
    }

    internal class Program
    {

        private static void Main(string[] args)
        {

            Dog dog = new Dog();
            IYell iterYell = dog as IYell;
            iterYell.Yell();


            //输入用户名
            Console.WriteLine("请输入您的名字");
            string userName = Console.ReadLine();
            Console.WriteLine("您的名字是：\"{0} \"", userName);

            Player user = new Player(userName, BasicPlayer.gender.Male, 200, 200);
            Player arno = new Player("Arno", BasicPlayer.gender.Male);

            Game.Fight(user, arno);

            Console.ReadKey();

        }
    }
}