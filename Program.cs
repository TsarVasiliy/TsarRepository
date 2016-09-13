using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
         
           again:
          try
          {
             
          Calc cl = new Calc();
          Cli cli = new Cli();

          cli.Show();

              switch (cli.Oper)
              {

                  case "+":
                      Console.WriteLine(cli.X + "+" + cli.Y + "=" + cl.sum(cli.X, cli.Y)); break;

                  case "-":
                      Console.WriteLine(cli.X + "-" + cli.Y + "=" + cl.sub(cli.X, cli.Y)); break;

                  case "*":
                      Console.WriteLine(cli.X + "*" + cli.Y + "=" + cl.mul(cli.X, cli.Y)); break;

                  case "/":
                      if (cli.Y == 0) { Console.WriteLine("На ноль делить нельзя"); break; }
                      Console.WriteLine(cli.X + "/" + cli.Y + "=" + cl.div(cli.X, cli.Y)); break;

                  default: Console.WriteLine("Неверный оператор"); break;
              }
          }
          catch 
          {
              Console.WriteLine("Введены неверные данные");
          }

          Console.WriteLine("Желаете продолжить (y?)");
          string prod = Console.ReadLine();
          if (prod == "y")
              goto again;
        
        }
        


    }
}
