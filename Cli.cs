using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Cli
    {
        double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        string oper;

        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        public void Show()
        {
                Console.WriteLine("Введите первое число");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                y = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите операцию (+, -, *, /)");
                oper = Console.ReadLine();
            
        }
    }
}
