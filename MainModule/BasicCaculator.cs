using System;

public class BasicCalculatorException : ApplicationException
{
    public BasicCalculatorException(string message) : base(message) { }
}

public class BasicCalculator
{
    //整数检查
    private static bool CheckInt(float num)
    {
        if (Math.Abs((int) num - num) > 0.00001)
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
        if(Math.Abs(num1) > 0.0001)
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
        float result = (float) Math.Pow(num0, num1);
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
            return ((int) num0 / (int) num1);
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
        float result = (float)Math.Pow(num0, 1/num1);
        if (double.IsNaN(result))
        {
            BasicCalculatorException e = new BasicCalculatorException("存在无法计算的开方数。");
            throw e;
        }
        return result;
    }
}
