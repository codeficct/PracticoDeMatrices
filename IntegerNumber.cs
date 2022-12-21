using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoDeMatrices
{
    internal class IntegerNumber
    {
        private int number;
        public IntegerNumber()
        {
            number = 0;
        }
        public void SetNumber(int value)
        {
            number = value;
        }

        public int GetNumber()
        {
            return number;
        }

        public bool IsPrime()
        {
            double half = Math.Sqrt(number);
            for (int i = 2; i <= half; i++)
            {
                if (number % i == 0) return false;
            }
            return number > 1;
        }

        public bool IsEven()
        {
            return number % 2 == 0;
        }
    }
}
