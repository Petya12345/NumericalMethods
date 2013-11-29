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

            double root = bisection.FindRoot(ref xl, ref xu, 0.0001, x=>(-3*x+5));


            Console.WriteLine("X = {0}", root);
            Console.Read();
        }
    }
}
