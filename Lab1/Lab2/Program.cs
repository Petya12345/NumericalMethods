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

            //var x = new double[] { 2, 3, 4};
            //var y = new double[] { 2, 3, 6 };
            var x = new double[] { -3.2, -2.1, 0.4, 0.7, 2, 2.5, 2.777};
            var y = new double[] { 10, -2, 0, -7, 7, 0, 0 };

            var result = lsq.Solve(x, y);

            Console.WriteLine("\n");
            Helpers.PrintVector("LSQ Result", result);

            Console.WriteLine("\n");
            Console.WriteLine("LSQ Polinomial Method");
            var lsqInterpolation = Helpers.InterpolateSimplePolinoma(result, -4D, 4D, 0.1);
            Helpers.PrintMatrix("LSQ Interpolation", lsqInterpolation);

            /*

            var spline = cubicSpline.Solve(x, y);
            Helpers.PrintMatrix("CubicSpline Result", spline);

            var splineInterpolation = Helpers.InterpolateQubicSplines(spline, 0, 4, 0.1, x);
            Helpers.PrintMatrix("Cubic Spline Interpolation", splineInterpolation);
            */

            Console.ReadKey();

        }
    }
}
