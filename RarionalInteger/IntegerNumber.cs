using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalInteger
{
    public class IntegerNumber : INumber, IInputOutput
    {
        public int number { get; set; }
               
        public IntegerNumber(int Number = 0)
        {
            number = Number;
        }

        //public RationalNumber DoRationalFromInteger()
        //{
        //    return new RationalNumber(this.number, 1);
        //}

        public INumber Adding(INumber number)
        {
            var num = number as IntegerNumber;
            return new IntegerNumber(this.number + num.number);
        }

        public INumber Substraction(INumber number)
        {
            var num = number as IntegerNumber;
            return new IntegerNumber(this.number - num.number);
        }

        public INumber Division(INumber number)
        {
            var num = number as IntegerNumber;
            return new IntegerNumber(this.number / num.number);
        }

        public INumber Multiplication(INumber number)
        {
            var num = number as IntegerNumber;
            return new IntegerNumber(this.number * num.number);
        }

        public override string ToString() => $"{number}";

        public void InputData(string line)
        {
            try
            {
                int num = Convert.ToInt32(line);
                this.number = num;
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }

        public void OutputData(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(this);
        }

        public object Clone()
        {
            return new IntegerNumber(number = this.number);
        }
    }
}
