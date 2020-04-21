using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalInteger
{
    public interface IInputOutput
    {
        void InputData(string line);
        void OutputData(StreamWriter streamWriter);
    }
}
