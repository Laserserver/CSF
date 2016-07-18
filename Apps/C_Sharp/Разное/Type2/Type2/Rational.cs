using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type2
{
    public struct RationalNumber
    {
        public int numerator;
        public int denominator;
    }
    public static class Rational
    {
        public static bool Equal(RationalNumber x1, RationalNumber x2)
        {
            return x1.numerator * x2.denominator == x1.denominator * x2.numerator;
        }
    }
}
