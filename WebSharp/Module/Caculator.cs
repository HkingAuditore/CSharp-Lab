using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace WebSharp.Module
{
    public class Calculator : BasicCalculator
    {
        public float Result { get; }

        public enum Operate
        {
            Plus=0,Minus,Multiply,Divide
        }

        delegate float DelOperator(float num0, float num1);

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

        public Calculator(float num0,float num1,Operate operate)
        {
            try
            {
                Result = _delOperators[(int) operate](num0, num1);
            }
            catch (BasicCalculatorException e)
            {
                throw e;
            }
        }
    }
}