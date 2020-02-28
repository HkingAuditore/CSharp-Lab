using System;

namespace WebSharp.Module
{
    public class Calculator : BasicCalculator
    {
        public float Result { get; }

        public enum Operate
        {
            Plus = 0, Minus, Multiply, Divide, Pow, ExactDivide, Remain, Root
        }

        private delegate float DelOperator(float num0, float num1);

        private const int _numOfOperators = 8;

        private static DelOperator[] _delOperators = new DelOperator[_numOfOperators]
        {
            BasicCalculator.Plus,
            BasicCalculator.Minus,
            BasicCalculator.Multiply,
            BasicCalculator.Divide,
            BasicCalculator.Pow,
            BasicCalculator.ExactDivide,
            BasicCalculator.Remain,
            BasicCalculator.Root
        };

        public Calculator(float num0, float num1, Operate operate)
        {
            try
            {
                Result = _delOperators[(int)operate](num0, num1);
            }
            catch (BasicCalculatorException e)
            {
                throw e;
            }
        }

        //数字检验
        private static bool IsNum(string input)
        {
            input = input.Trim();
            if (input[0] == '+' || input[0] == '-')
            {
                input = input.Remove(0, 1);
            }

            if (input.Split('.').Length > 2)
            {
                BasicCalculatorException e = new BasicCalculatorException("多余一个的小数点！");
                throw e;
            }
            foreach (var c in input)
            {
                if (!Char.IsNumber(c))
                {
                    if(c == '.')continue;
                    BasicCalculatorException e = new BasicCalculatorException("存在非数字！");
                    throw e;
                }
            }
            return true;
        }

        public static float InterpretInput(string input)
        {
            try
            {
                IsNum(input);
                return (float)Convert.ToDecimal(input);
            }
            catch (BasicCalculatorException e)
            {
                throw e;
            }
            catch (System.FormatException e)
            {
                BasicCalculatorException et = new BasicCalculatorException("存在非数字！(来自报错System.FormatException）");
                throw et;
            }
        }
    }
}