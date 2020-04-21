using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalInteger
{
    public class RationalNumber : INumber, IInputOutput
    {
        public int numerator;
        public int denominator;

        public RationalNumber(int num = 0, int denom = 1)
        {
            numerator = num;
            denominator = denom;
        }

        public static implicit operator RationalNumber(IntegerNumber x)
        {
            return new RationalNumber { numerator = x.number, denominator = 1 };
        }

        public INumber Adding(INumber number)
        {
            var num = number as RationalNumber;
            return new RationalNumber(this.numerator * num.denominator + this.denominator * num.numerator, num.denominator * this.denominator);
        }

        public INumber Division(INumber number)
        {
            var num = number as RationalNumber;
            return new RationalNumber(this.numerator * num.denominator, this.denominator * num.numerator);
        }

        public INumber Multiplication(INumber number)
        {
            var num = number as RationalNumber;
            //перевірка
            return new RationalNumber(this.numerator * num.numerator, num.denominator * this.denominator);
        }

        public INumber Substraction(INumber number)
        {
            var num = number as RationalNumber;
            return new RationalNumber(this.numerator * num.denominator - this.denominator * num.numerator, num.denominator * this.denominator);
        }

        public override string ToString() => $"{numerator}/{denominator}";

        public void InputData(string line)
        {
            string[] info = line.Split('/');
            this.numerator = Convert.ToInt32(info[0]);
            this.denominator = Convert.ToInt32(info[1]);
        }

        public static int GCD(int a, int b)
        {
            int remainder;

            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);
            if (b > a)
            {
                remainder = a;
                a = b;
                b = remainder;
            }

            do
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            while (remainder != 0);
            return a;
        }

        public static void Transform(INumber a)
        {
            var num = a as RationalNumber;
            if (num.numerator != 0)
            {
                int res = GCD(num.numerator, num.denominator);

                if (res != 1)
                {
                    num.numerator /= res;
                    num.denominator /= res;
                }
            }
        }

        public void OutputData(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(this);
        }

        public object Clone()
        {
            return new RationalNumber(numerator = this.numerator, denominator = this.denominator);
        }
    }
}
