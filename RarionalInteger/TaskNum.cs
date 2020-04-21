using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Визначити інтерфейс INumber з арифметичними операціями
//додавання, віднімання, множення, ділення та інтерфейс IInputOutput
//для форматного введення-виведенням INumber з файлу.
//Класи RationalNumber та IntegerNumber повинні реалізувати ці два інтерфейси. 
//Клас Task містить список елементів типу INumber та методи, які знаходять
//суму, добуток та середнє арифметичне значення елементів заданого масиву типу INumber.
//Додатково він реалізує інтерфейс ICloneable.Ввести з файлу масив чисел - раціональних та цілих,
//в об’єкт типу Task, склонувати цей об’єкт в інший.
//Знайти суму елементів першого масиву, добуток та середнє арифметичне значення елементів другого.
//Результат вивести в файл. Також покрити код юніт тестами


namespace RationalInteger
{
    public class TaskNum : ICloneable
    {
        public List<INumber> numbers;

        public TaskNum(List<INumber> list)
        {
            numbers = list;
        }

        public TaskNum()
        {
            numbers = new List<INumber>();
        }

        public INumber Sum()
        {
            INumber res = new RationalNumber(0, 1);
            foreach (var i in this.numbers)
            {
                res = res.Adding(i);
            }
            RationalNumber.Transform(res);
            return res;
        }

        public INumber Average()
        {
            INumber sum = this.Sum();
            INumber divider = new RationalNumber(this.numbers.Count, 1);
            INumber res = sum.Division(divider);
            RationalNumber.Transform(res);
            return res;

        }

        public INumber Dobutok()
        {
            INumber res = new RationalNumber(1, 1);
            foreach (var i in this.numbers)
            {
                res = res.Multiplication(i);
            }
            RationalNumber.Transform(res);
            return res;
        }

        public static TaskNum InputData(StreamReader streamReader)
        {
            string line;
            TaskNum task = new TaskNum();
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.IndexOf('/') != -1)
                {
                    INumber newNum = new RationalNumber();
                    newNum.InputData(line);
                    task.numbers.Add(newNum);
                }
                else
                {
                    INumber newNum = new IntegerNumber();
                    newNum.InputData(line);
                    IntegerNumber intNum = newNum as IntegerNumber;
                    RationalNumber ratNum = new RationalNumber { numerator = intNum.number, denominator = 1 };
                    task.numbers.Add(ratNum);
                }
            }
            return task;
        }

        public static void OutputData(StreamWriter streamWriter, TaskNum task)
        {
            foreach (INumber i in task.numbers)
            {
                i.OutputData(streamWriter);
            }
        }

        public object Clone()
        {
            List<INumber> cloned = new List<INumber>();
            foreach (INumber i in numbers)
            {
                cloned.Add((INumber)i.Clone());
            }
            return new TaskNum(cloned);
        }
    }
}
