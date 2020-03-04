using System;
using System.Collections.Generic;

interface IEquation
{
    List<float> GetRoot();
}

public class BasicCalculatorException : ApplicationException
{
    public BasicCalculatorException(string message) : base(message)
    {
    }
}

public class BasicCalculator
{
    //整数检查
    private static bool CheckInt(float num)
    {
        if (Math.Abs((int)num - num) > 0.00001)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected static float Plus(float num0, float num1) => num0 + num1;

    protected static float Minus(float num0, float num1) => num0 - num1;

    protected static float Multiply(float num0, float num1) => num0 * num1;

    protected static float Divide(float num0, float num1)
    {
        float result;
        if (Math.Abs(num1) > 0.0001)
        {
            result = num0 / num1;
        }
        else
        {
            BasicCalculatorException e = new BasicCalculatorException("除数为0。");
            throw e;
        }

        return result;
    }

    protected static float Pow(float num0, float num1)
    {
        float result = (float)Math.Pow(num0, num1);
        if (double.IsNaN(result))
        {
            BasicCalculatorException e = new BasicCalculatorException("存在无法计算的乘方数。");
            throw e;
        }
        return result;
    }

    protected static float ExactDivide(float num0, float num1)
    {
        if (CheckInt(num0) && CheckInt(num1))
        {
            return ((int)num0 / (int)num1);
        }
        else
        {
            BasicCalculatorException e = new BasicCalculatorException("整除应输入整数。");
            throw e;
        }
    }

    protected static float Remain(float num0, float num1)
    {
        if (CheckInt(num0) && CheckInt(num1))
        {
            return ((int)num0 % (int)num1);
        }
        else
        {
            BasicCalculatorException e = new BasicCalculatorException("取余应输入整数。");
            throw e;
        }
    }

    protected static float Root(float num0, float num1)
    {
        float result = (float)Math.Pow(num0, 1 / num1);
        if (double.IsNaN(result))
        {
            BasicCalculatorException e = new BasicCalculatorException("存在无法计算的开方数。");
            throw e;
        }
        return result;
    }

}

//方程类
public class Equation : BasicCalculator
{
    public readonly int Degree;
    public List<float> Result { get; protected set;} = new List<float>();

    public Equation(int degree,params float[] fictions)
    {
        Degree = degree;
    }

    //解方程
    public int Solve()
    {
        if (this is IEquation solver)
        {
            this.Result = solver.GetRoot();
            return this.Result.Count;
        }

        return 0;
    }
}

//二次方程类
class TwoDegreeEquation : Equation,IEquation
{
    //零次系数
    private float FictionA { get; set; }
    //一次系数
    private float FictionB { get; set; }
    //二次系数
    private float FictionC { get; set; }


    public TwoDegreeEquation(int degree, params float[] fictions) : base(2, fictions)
    {
        FictionA = fictions[0];
        FictionB = fictions[1];
        FictionC = fictions[2];
        this.Solve();
    }

    public List<float> GetRoot()
    {
        //判别式
        float delta = FictionB * FictionB - 4 * FictionA * FictionC;
        //判别式小于零，无解
        if (delta < 0)
        {
            BasicCalculatorException e = new BasicCalculatorException("二次方程无解！");
            throw e;
        }
        this.Result.Add(((-FictionB) + (float)Math.Sqrt(delta)) / (2 * FictionC));
        //判别式大于零，两个解
        if (delta > 0)
        {
            this.Result.Add(((-FictionB) - (float)Math.Sqrt(delta)) / (2 * FictionC));
        }
        return Result;
    }
}

//一次方程类
class OneDegreeEquation : Equation,IEquation
{
    private float FictionA { get; set; }
    private float FictionB { get; set; }

    public OneDegreeEquation(int degree, params float[] fictions) : base(1, fictions)
    {
        FictionA = fictions[0];
        FictionB = fictions[1];
        this.Solve();
    }

    public List<float> GetRoot()
    {
        this.Result.Add((-FictionA) / FictionB); 
        return Result;
    }

}
