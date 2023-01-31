using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int n, int m)
        {
            return n + m;
        }
        public double Add(double n, double m, double i)
        {
            return n + m + i;
        }
        public decimal Add(decimal n, decimal m, decimal i)
        {
            return n + m + i;
        }
    }
}
