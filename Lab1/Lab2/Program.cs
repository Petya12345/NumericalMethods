﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lsq = new Algorithms.LSQ();
            var cubicSpline = new Algorithms.CubicSpline();
            //var x = new double[] { 0, 3.3, 6.6, 9.9 };
            //var y = new double[] { 2.1, 5.9, 2.4, 3.4 };

            var x = new double[] { -2, 0, 1, 2, 4, 5};
            var y = new double[] { -1, -5, -4, -1, 11, 20 };

            var result = lsq.Solve(x, y);
            Helpers.PrintVector("LSQ Result", result);

            var spline = cubicSpline.Solve(x, y);
            Helpers.PrintMatrix("CubicSpline Result", spline);

            var lsqInterpolation = Helpers.InterpolateSimplePolinoma(result, x.Min(), x.Max(), 0.1);
            Helpers.PrintMatrix("LSQ Interpolation", lsqInterpolation);

            var splineInterpolation = Helpers.InterpolateQubicSplines(spline, x.Min(), x.Max(), 0.1, x);
            Helpers.PrintMatrix("Cubic Spline Interpolation", splineInterpolation);
            Console.ReadKey();

        }
    }
}
