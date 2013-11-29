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

            Func<double, double> fn1 = x => (x * Math.Pow(Math.E, 0.8 - x)) - 0.12; //Andris x*e^(0.8-x) - 0.12
            Func<double, double> fn2 = x => (x * x * Math.Sin(x)) - 0.12; //Alina (x^2)*sinx - 0.12
            Func<double, double> fn3 = x => (Math.Pow(Math.Log(x), 2) / x) - 12; //Moritz ((lnx)^2)/x - 12

            Func<double, double> fn1d = x => -2.22554 * Math.Pow(Math.E, (-x)) * (-1 + x); //Andris
            Func<double, double> fn2d = x => x * (x * Math.Cos(x)+2*Math.Sin(x)); //Alina
            Func<double, double> fn3d = x => -((-2 + Math.Log(x)) * Math.Log(x)) / Math.Pow(x, 2); //Moritz

            var newtons = new Algorithms.NewtonsCombined();
            Console.WriteLine("Andris x*e^(0.8-x) - 0.12 - Newtons Method - eps = 0.01, eps for bisection = 0.1");
            newtons.FindRoot(fn1, fn1d, 0, 1, 0.1, 0.01);
            Console.WriteLine("Alina (x^2)*sinx - 0.12 - Newtons Method - eps = 0.01, eps for bisection = 0.1");
            newtons.FindRoot(fn2, fn2d, 3, 4, 0.1, 0.01);
            Console.WriteLine("Moritz ((lnx)^2)/x - 12 - Newtons Method - eps = 0.01, eps for bisection = 0.1");
            newtons.FindRoot(fn3, fn3d, 0, 1, 0.1, 0.01);
            Console.Read();
        }
    }
}
