using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSharp.Process
{
    class Calculator
    {
        // 加法
        public float Add(float x,float y)
        {
            return x + y;
        }

        //减法
        public float Minus(float x, float y)
        {
            return x - y;
        }

        //乘法
        public float Multiply(float x, float y)
        {
            return x * y;
        }

        //除法
        public float Divide(float x, float y)
        {
            if (y == 0) return 0;
            return x / y;
        }

        public float Divide(int x, int y)
        {
            if (y == 0) return 0;
            return (float)x / (float)y;
        }
    }
}
