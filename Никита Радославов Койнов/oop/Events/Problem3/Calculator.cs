using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3
{
    public delegate int CalculationStragegy(int firstOperand, int secondOperand);

    public class Calculator
    {
        private CalculationStragegy calculationStragegy = (f, s) => f + s;

        public void ChangeStrategy(CalculationStragegy stragegy)
        {
            this.calculationStragegy = stragegy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculationStragegy.Invoke(firstOperand, secondOperand);
        }
    }
}
