using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            var bisection = new Algorithms.Bisection();
            double xl = 0, xu = 20;

            double root = bisection.FindRoot(xl, xu, 0.1, x=>Math.Sin(x));


            Console.WriteLine("X = {0}", root);
            Console.Read();
        }
    }
}
