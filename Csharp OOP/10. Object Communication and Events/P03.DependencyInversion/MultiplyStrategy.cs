using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion
{
    public class MultiplyStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
