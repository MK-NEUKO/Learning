using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class AverageCalculator
    {
        public double CalculateAverage(double[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }
    }
}
