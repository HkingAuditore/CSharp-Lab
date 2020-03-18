using System;

internal delegate void MyDel();

public class BasicPlayer
{
    public enum gender
    {
        Male, Female
    }

    public string Name { get; }
    public readonly gender Gender;
    public int Age { get; }
    public int HP { get; set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }

    protected const int _initAge = 18;
    protected int _initHP = 100;
    protected const int _initValue = 10;

    private int _attack;
    private int _defence;
    private float _damageFactor = 0.5f;
    private int _levelExp = 100;


    public event EventHandler LevelUpEvent;

    public BasicPlayer(string name, gender gender, int attack, int defence, int age = _initAge)
    {
        Name = name;
        Gender = gender;
        Age = age;
        HP = _initHP;
        _attack = attack;
        _defence = defence;
        Level = 1;
        Exp = 0;

        LevelUpEvent += LevelUp;
    }

    public BasicPlayer() : this("None", gender.Male, _initAge, _initValue, _initValue)
    {
    }

    public BasicPlayer(string name, gender gender, int age = _initValue) : this(name, gender, _initValue, _initValue, age)
    {
        MyDel del = () => { Console.WriteLine("角色生成！"); };
        del();
    }

    /// <summary>
    /// 攻击
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public int Attack(BasicPlayer enemy)
    {
        int damage = (int)(Math.Abs(this._attack - enemy._defence) * _damageFactor);
        enemy.HP -= damage;
        return damage;
    }

    protected bool IsLevelUp(BasicPlayer player)
    {
        if (this.Exp >= 100)
        {
            this.Exp -= 100 ;
            return true;
        }

        return false;
    }

    protected void LevelUp(Object source,EventArgs e)
    {
        this.Level++;
        this._attack = (int)(this._attack * 1.5);
        this._defence = (int)(this._defence * 1.5);
    }

    /// <summary>
    /// 增加经验值
    /// </summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    public int AddExp(int exp)
    {
        this.Exp += exp;
        if (IsLevelUp(this))
        {
            LevelUpEvent(this, null);
        }

        return this.Level;
    }

}