﻿using System;

namespace ConsoleSharp.Module
{
    internal class Player : BasicPlayer
    {
        public Player(string name, gender gender, int attack, int defence, int age = _initAge) : base(name, gender,
            attack, defence, age)
        {
            LevelUpEvent += LevelUpShow;
        }

        public Player(string name, gender gender, int age = _initAge) : this(name, gender,_initValue,_initValue, age)
        {
        }

        public void KillShow(Player enemy, int damage)
        {
            enemy.HP = 0;
            Console.WriteLine(this.Name + " 对 " + enemy.Name + "造成 " + damage + " 伤害,将 " + enemy.Name + " 杀死");
            Console.WriteLine("当前HP：{0} - {1} ,{2} - {3}", this.Name, this.HP, enemy.Name, enemy.HP);
        }

        public void AttackShow(Player enemy, int damage)
        {
            Console.WriteLine(this.Name + " 对 " + enemy.Name + "造成 " + damage + " 伤害");
            Console.WriteLine("当前HP：{0} - {1} ,{2} - {3}", this.Name, this.HP, enemy.Name, enemy.HP);
        }

        public void LevelUpShow(Object source, EventArgs e)
        {
            Console.WriteLine(this.Name + " 升级了，当前等级 " + this.Level);
        }
    }
}