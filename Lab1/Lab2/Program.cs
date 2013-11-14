using System;
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
            var x = new double[] { 0, 3.3, 6.6, 9.9 };
            var y = new double[] { 2.1, 5.9, 2.4, 3.4 };

            var x2 = new double[] { 2, 3, 4};
            var y2 = new double[] { 2, 3, 6 };

            var result = lsq.Solve(x2, y2);
            Helpers.PrintVector("LSQ Result", result);

            var spline = cubicSpline.Solve(x2, y2);
            Helpers.PrintMatrix("CubicSpline Result", spline);

            var lsqInterpolation = Helpers.InterpolateSimplePolinoma(result, 2D, 4D, 0.1);
            Helpers.PrintMatrix("LSQ Interpolation", lsqInterpolation);

            var splineInterpolation = Helpers.InterpolateQubicSplines(spline, 2, 4, 0.1, x2);
            Helpers.PrintMatrix("Cubic Spline Interpolation", splineInterpolation);
            Console.ReadKey();

        }
    }
}
