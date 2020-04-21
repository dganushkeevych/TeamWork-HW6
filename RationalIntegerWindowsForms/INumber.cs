using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalInteger
{
    public interface INumber : IInputOutput, ICloneable
    {
        INumber Adding(INumber number);
        INumber Division(INumber number);
        INumber Multiplication(INumber number);
        INumber Substraction(INumber number);
    }
}
