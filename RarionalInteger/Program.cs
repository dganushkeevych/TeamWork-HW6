using RationalInteger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarionalInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = @"inputData.txt";
            var file = new FileStream(inPath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(file);

            string outPath = @"outputData.txt";
            StreamWriter streamWriter = new StreamWriter(outPath, true, System.Text.Encoding.Default);


            TaskNum task = new TaskNum();
            task = TaskNum.InputData(streamReader);
            //TaskNum.OutputData(streamWriter, task);
            INumber sum = task.Sum();
            streamWriter.WriteLine($"Sum : {sum}");

            TaskNum task1 = task.Clone() as TaskNum;
            //TaskNum.OutputData(streamWriter, task);
            INumber avg = task1.Average();
            INumber dobutok = task1.Dobutok();
            streamWriter.WriteLine($"Average : {avg}    Dobutok : {dobutok}");

            streamReader.Close();
            streamWriter.Close();

            Console.Read();
        }
    }
}
