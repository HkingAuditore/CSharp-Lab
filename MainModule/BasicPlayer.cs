using System;

public class BasicPlayer
{
    public string Name { get; }
    public readonly bool Gender;
    public int Age { get; }
    public int HP { get; set; }


    protected const int _initAge = 18;
    protected int _initHP = 100;
    protected const int _initValue = 10;

    private int _attack;
    private int _defence;
    private float _damageFactor = 0.5f;


    public BasicPlayer(string name, bool gender, int attack, int defence, int age = _initAge)
    {
        Name = name;
        Gender = gender;
        Age = age;
        HP = _initHP;

        _attack = attack;
        _defence = defence;
    }


    public BasicPlayer() : this("None", true, _initAge, _initValue, _initValue){}

    public BasicPlayer(string name, bool gender, int age = _initValue) : this(name,gender,_initValue,_initValue,age) { }

    public int Attack(BasicPlayer enemy)
    {
        int damage = (int)(Math.Abs(this._attack - enemy._defence) * _damageFactor);
        enemy.HP -= damage;
        return damage;
    }


}
