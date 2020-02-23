using System;

public class BasicPlayer
{
    public string Name { get; }
        public readonly bool Gender;
        public int Age { get; }
        public int HP { get; set; }


        private const int _initAge = 18;
        private int _initHP = 100;
        private int _initValue = 10;

        private int _attack;
        private int _defence;
        private float _damageFactor = 0.5f;


        public BasicPlayer(string name, bool gender)
        {
            Name = name;
            Gender = gender;
            Age = _initAge;
            HP = _initHP;

            _attack = _initValue;
            _defence = _initValue;
        }

        public BasicPlayer(string name, bool gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            HP = _initHP;

            _attack = _initValue;
            _defence = _initValue;
        }

        public BasicPlayer(string name, bool gender, int attack, int defence, int age = _initAge)
        {
            Name = name;
            Gender = gender;
            Age = age;
            HP = _initHP;

            _attack = attack;
            _defence = defence;
        }


        public int Attack(BasicPlayer enemy)
        {
            int damage = (int)(Math.Abs(this._attack - enemy._defence) * _damageFactor);
            enemy.HP -= damage;
            return damage;
        }

        public void KillShow(BasicPlayer enemy, int damage)
        {
            enemy.HP = 0;
            Console.WriteLine("对 {0} 造成 {1} 伤害,将 {0} 杀死", enemy.Name, damage);
            Console.WriteLine("当前HP：{0} - {1} ,{2} - {3}", this.Name, this.HP, enemy.Name, enemy.HP);
        }

        public void AttackShow(BasicPlayer enemy, int damage)
        {
            Console.WriteLine("对 {0} 造成 {1} 伤害", enemy.Name, damage);
            Console.WriteLine("当前HP：{0} - {1} ,{2} - {3}", this.Name, this.HP, enemy.Name, enemy.HP);

        }
}
