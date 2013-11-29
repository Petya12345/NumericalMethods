using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Algorithms
{
    class NewtonsCombined
    {
        public double FindRoot(Func<double, double> function, Func<double, double> derivative, double a, double b, double eps1, double eps2)
        {
            var bisectA = a;
            var bisectB = b;
            new Bisection().FindRoot(ref a, ref b, eps1, function);
            Console.WriteLine("Interval after bisection: [{0};{1}]", a, b);
            double xPrev = (a + b) / 2;
            Console.Write("{0} ", xPrev);
            double x = 0;
            int i;
            for (i = 0; i < 10000; i++) //prevent infinite loop 
            {
                x = xPrev - function(xPrev) / derivative(xPrev);
                Console.Write("{0} ", x);
                if (Math.Abs(x - xPrev) < eps2)
                {
                    break;
                }
                xPrev = x;
            }
            Console.WriteLine("Finished in {0} iterations", i);
            return x;
        }
    }
}
