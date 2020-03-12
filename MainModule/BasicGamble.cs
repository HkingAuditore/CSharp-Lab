using System;
using System.Collections.Generic;


public delegate float DeleGetReward(float reward);
public enum GambleChoose
{
    Big, Small
}

public class BasicGambleException : ApplicationException
{
    public BasicGambleException(string message) : base(message)
    {
    }
}


public class Gambler:IComparable<Gambler>
{
    public string ID;
    public float ContributeMoney { get; }
    public float Reward { get; set; }
    public DeleGetReward GetReward;

    public GambleChoose Choose;

    public Gambler(string id,GambleChoose choose, float contributeMoney,DeleGetReward getReward)
    {
        this.ID = id;
        this.Choose = choose;
        this.ContributeMoney = contributeMoney;
        this.GetReward = getReward;
    }


    public int CompareTo(Gambler other)
    {
        if (other == null) return -1;
        if (this.ContributeMoney > other.ContributeMoney)
        {
            return -1;
        }

        return 1;
    }
}


public class BasicGamble
{

    /// <summary>
    /// 赌博流程：
    /// 玩家猜大小，交钱入局。
    /// 开盘后，猜对的可以分钱。
    /// 获胜玩家拿走场上的钱。
    /// 钱以红包形式发放，出资越高者拿大头概率越高。
    /// 不会出现赢家血本无归，但是出资越少越有几率出现亏损。
    /// </summary>
    /// 

    public List<Gambler> Gamblers { get; private set; } = new List<Gambler>();
    public float GamblingMoney { get; private set; }
    public int DiceResult { get; private set; }



    

    public BasicGamble()
    {
        GamblingMoney = 0;

    }

    /// 赌徒入局
    public void AddGambler(BasicUser gambler, float money,GambleChoose choose)
    {

        Gamblers.Add(new Gambler(gambler.UserID, choose, money,gambler.ChangeMoney));
        gambler.ChangeMoney(-money);
        GamblingMoney += money;

    }

    /// 赌徒离局
    // public void RemoveGambler(BasicUser gambler)
    // {
    //     if (!Gamblers.Contains(gambler))
    //     {
    //         BasicGambleException e = new BasicGambleException("不在此赌局！");
    //         throw e;
    //     }
    //
    //     Gamblers.Remove(gambler);
    // }

    /// 开启并处理赌局
    public void StartGamble()
    {
        RollingDice();
        if (DiceResult <= 3)
        {
            DistributeMoney(GambleChoose.Small);
        }
        else
        {
            DistributeMoney(GambleChoose.Big);
        }
    }

    /// 分配赌资
    private void DistributeMoney(GambleChoose winChoose)
    {
        List<Gambler> winners  = new List<Gambler>();
        
        float winnersContribute = 0;
        foreach (var gambler in Gamblers)
        {
            if (gambler.Choose == winChoose)
            {
                winnersContribute += gambler.ContributeMoney;
                winners.Add(gambler);
            }
        }
        winners.Sort();
        for (int i = 0; i < winners.Count; i++)
        {
            if (i == winners.Count - 1)
            {
                winners[i].Reward = (float)Math.Round(GamblingMoney,2);
                GamblingMoney = 0;
                break;
            }
            DistributeGamblerMoney(winners[i], winnersContribute);
            winnersContribute -= winners[i].ContributeMoney;
        }
    }


    ///  分配赌徒个人赌资
    private float DistributeGamblerMoney(Gambler gambler,float winnersContribute)
    {
        Random luck = new Random();
        float minRate = gambler.ContributeMoney / winnersContribute;
        double actualRate = luck.NextDouble();
        // 概率重映射
        if (actualRate < minRate) actualRate = actualRate / minRate * (1 - minRate) + minRate;
        gambler.Reward = (float) Math.Round(actualRate * GamblingMoney,2);
        gambler.GetReward(gambler.Reward);
        GamblingMoney -= gambler.Reward;
        return gambler.Reward;
    }

    /// 投骰子
    private void RollingDice()
    {
        Random dice = new Random();
        DiceResult = dice.Next(1, 7);
    }
}
