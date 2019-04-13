using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion
{
    public class DivideStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
