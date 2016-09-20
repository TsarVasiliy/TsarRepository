using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleApplication1;

namespace Test
{
    public class Class1
    {

        [Test]
        public void SumPositiveNumbers()
        {   
            
            var calc = new Calc();
            double first = 12;
            double second = 3;
            Assert.AreEqual(15, calc.sum(first, second));
        }


        [Test]
        public void SumNegativeNumbers()
        {

            var calc = new Calc();
            double first = -12;
            double second = -3;
            Assert.AreEqual(-15, calc.sum(first, second));
        }


        [Test]
        public void Sumfailed()
        {

            var calc = new Calc();
            double first = 1;
            double second = 3;
            Assert.AreEqual(15, calc.sum(first, second));
        }

        [Test]
        public void SubPositiveNumbers()
        {

            var calc = new Calc();
            double first = 4;
            double second = 1;
            Assert.AreEqual(3, calc.sub(first, second));
        }

        [Test]
        public void SubNegatineNumbers()
        {

            var calc = new Calc();
            double first = -4;
            double second = -1;
            Assert.AreEqual(-3, calc.sub(first, second));
        }

        [Test]
        public void SubFaled()
        {

            var calc = new Calc();
            double first = -4;
            double second = -1;
            Assert.AreEqual(3, calc.sub(first, second));
        }

        [Test]
        public void MulPositiveNumbers()
        {

            var calc = new Calc();
            double first = 5;
            double second = 6;
            Assert.AreEqual(30, calc.mul(first, second));
        }

        [Test]
        public void MulNegativeNumbers()
        {

            var calc = new Calc();
            double first = -5;
            double second = -6;
            Assert.AreEqual(30, calc.mul(first, second));
        }

        [Test]
        public void MulFailed()
        {

            var calc = new Calc();
            double first = -5;
            double second = -6;
            Assert.AreEqual(-30, calc.mul(first, second));
        }

        [Test]
        public void DivPositiveNumbers()
        {

            var calc = new Calc();
            double first = 20;
            double second = 5;
            Assert.AreEqual(4, calc.div(first, second));
        }

        [Test]
        public void DivNegativeNumbers()
        {

            var calc = new Calc();
            double first = -20;
            double second = -4;
            Assert.AreEqual(5, calc.div(first, second));
        }

        [Test]
        public void Divfailed()
        {

            var calc = new Calc();
            double first = 20;
            double second = 5;
            Assert.AreEqual(8, calc.div(first, second));
        }
    }
}
