using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RationalInteger;
using RationalIntegerWindowsForms;

namespace RationalIntegerUnitTest
{
    [TestClass]
    public class RationalIntegerUnitTest
    {
        public void GetData(TaskNum task)
        {
            task.numbers.Add(new RationalNumber(7, 1));
            task.numbers.Add(new RationalNumber(8, 1));
            task.numbers.Add(new RationalNumber(9, 1));
            task.numbers.Add(new RationalNumber(7, 8));
            task.numbers.Add(new RationalNumber(9, 10)); 
        }

        [TestMethod]
        public void SumTestMethod()
        {
            TaskNum task = new TaskNum();
            GetData(task);
            RationalNumber res = task.Sum() as RationalNumber;

            RationalNumber expetedRes = new RationalNumber(1031, 40);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void AverageTestMethod()
        {
            TaskNum task = new TaskNum();
            GetData(task);
            RationalNumber res = task.Average() as RationalNumber;

            RationalNumber expetedRes = new RationalNumber(1031, 200);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void DobutokTestMethod()
        {
            TaskNum task = new TaskNum();
            GetData(task);
            RationalNumber res = task.Dobutok() as RationalNumber;

            RationalNumber expetedRes = new RationalNumber(3969, 10);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void CloneTestMethod()
        {
            TaskNum task = new TaskNum();
            GetData(task);
            TaskNum cloneTask = task.Clone() as TaskNum;

            Assert.AreEqual(task.numbers.Count, cloneTask.numbers.Count);
        }

        [TestMethod]
        public void IntegerToDationalImplicitConversionTestMethod()
        {
            IntegerNumber test = new IntegerNumber(5);
            RationalNumber res = new RationalNumber { numerator = test.number, denominator = 1 };

            RationalNumber expectedRes = new RationalNumber(5, 1);
            Assert.IsTrue(expectedRes.denominator == res.denominator && res.numerator == expectedRes.numerator);

        }

        [TestMethod]
        public void InputDataTestMethodRational()
        {
            string line = "61/140";
            RationalNumber res = new RationalNumber();
            res.InputData(line);

            RationalNumber expetedRes = new RationalNumber(61, 140);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void InputDataTestMethodInteger()
        {
            string line = "61";
            IntegerNumber res = new IntegerNumber();
            res.InputData(line);

            IntegerNumber expetedRes = new IntegerNumber(61);

            Assert.AreEqual(res.number, expetedRes.number);
        }

        [TestMethod]
        public void OutputDataTestMethodRational()
        {
            RationalNumber res = new RationalNumber(61, 140);
            string expectedRes = res.ToString();
            Assert.AreEqual("61/140", expectedRes);

        }

        [TestMethod]
        public void OutputDataTestMethodInteger()
        {
            IntegerNumber res = new IntegerNumber(61);
            string expectedRes = res.ToString();
            Assert.AreEqual("61", expectedRes);
        }

        [TestMethod]
        public void AddingTestMethodIntegerToInteger()
        {
            IntegerNumber integer1 = new IntegerNumber(5);
            IntegerNumber integer2 = new IntegerNumber(5);

            IntegerNumber res = integer1.Adding(integer2) as IntegerNumber;
            IntegerNumber expetedRes = new IntegerNumber(10);

            Assert.IsTrue(expetedRes.number == res.number);
        }

        [TestMethod]
        public void AddingTestMethodRationalToRational()
        {
            RationalNumber rational1 = new RationalNumber(4, 5);
            RationalNumber rational2 = new RationalNumber(1, 5);
            RationalNumber expetedRes = new RationalNumber(1, 1);

            RationalNumber res = rational1.Adding(rational2) as RationalNumber;
            RationalNumber.Transform(res);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void SubstractionTestMethodIntegerToInteger()
        {
            IntegerNumber integer1 = new IntegerNumber(5);
            IntegerNumber integer2 = new IntegerNumber(5);

            IntegerNumber res = integer1.Substraction(integer2) as IntegerNumber;
            IntegerNumber expetedRes = new IntegerNumber(0);

            Assert.IsTrue(expetedRes.number == res.number);
        }

        [TestMethod]
        public void SubstractionTestMethodRationalToRational()
        {
            RationalNumber rational1 = new RationalNumber(4, 5);
            RationalNumber rational2 = new RationalNumber(1, 5);
            RationalNumber expetedRes = new RationalNumber(3, 5);

            RationalNumber res = rational1.Substraction(rational2) as RationalNumber;
            RationalNumber.Transform(res);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void MultiplicactionTestMethodIntegerToInteger()
        {
            IntegerNumber integer1 = new IntegerNumber(5);
            IntegerNumber integer2 = new IntegerNumber(5);

            IntegerNumber res = integer1.Multiplication(integer2) as IntegerNumber;
            IntegerNumber expetedRes = new IntegerNumber(25);

            Assert.IsTrue(expetedRes.number == res.number);
        }

        [TestMethod]
        public void MultiplicactionTestMethodRationalToRational()
        {
            RationalNumber rational1 = new RationalNumber(4, 5);
            RationalNumber rational2 = new RationalNumber(1, 5);
            RationalNumber expetedRes = new RationalNumber(4, 25);

            RationalNumber res = rational1.Multiplication(rational2) as RationalNumber;
            RationalNumber.Transform(res);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void DivisionTestMethodIntegerToInteger()
        {
            IntegerNumber integer1 = new IntegerNumber(5);
            IntegerNumber integer2 = new IntegerNumber(5);

            IntegerNumber res = integer1.Division(integer2) as IntegerNumber;
            IntegerNumber expetedRes = new IntegerNumber(1);

            Assert.IsTrue(expetedRes.number == res.number);
        }

        [TestMethod]
        public void DivisionTestMethodRationalToRational()
        {
            RationalNumber rational1 = new RationalNumber(4, 5);
            RationalNumber rational2 = new RationalNumber(1, 5);
            RationalNumber expetedRes = new RationalNumber(4, 1);

            RationalNumber res = rational1.Division(rational2) as RationalNumber;
            RationalNumber.Transform(res);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void TransformTestMethod()
        {
            RationalNumber expetedRes = new RationalNumber(61, 140);

            RationalNumber res = new RationalNumber(305, 700);
            RationalNumber.Transform(res);

            Assert.IsTrue(expetedRes.denominator == res.denominator && res.numerator == expetedRes.numerator);
        }

        [TestMethod]
        public void GCDTestMethod()
        {
            int res = RationalNumber.GCD(305, 610);
            Assert.AreEqual(res, 305);
        }

    }
}
