using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MedianCalculator
    {
        public double CalculateMedian(double[] numbers)
        {
            var numbersCloned = (double[])numbers.Clone();
            Array.Sort(numbersCloned);
            var sice = numbersCloned.Length;
            var mid = sice / 2;

            if (sice % 2 != 0)
            {
                return numbersCloned[mid];
            }

            var midValue1 = numbersCloned[mid];
            var midValue2 = numbersCloned[mid - 1];
            return (midValue1 + midValue2) / 2;
        }
    }
}
