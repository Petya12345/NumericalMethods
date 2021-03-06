﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Algorithms
{
    class Bisection
    {
        public double FindRoot(ref double xl, ref double xu, double e, Func<double, double> function, ref int numOfIterations)
        {
            double delta = xu - xl;
            Console.WriteLine("Lower: {0}, Upper: {1}, Delta: {2}", xl, xu, delta);

            double xr = (xl + xu) / 2;
            if (function(xl) * function(xr) < 0) xu = xr;
            else xl = xr;

            if (delta <= e) return xr;
            else return FindRoot(ref xl, ref xu, e, function, ref numOfIterations);
        }

        public double f(double x)
        {
            return -3 * x + 5;
        }
    }
}
