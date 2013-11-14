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

            ////http://www.machinelearning.ru/wiki/index.php?title=%D0%98%D0%BD%D1%82%D0%B5%D1%80%D0%BF%D0%BE%D0%BB%D1%8F%D1%86%D0%B8%D1%8F_%D0%BA%D1%83%D0%B1%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%BC%D0%B8_%D1%81%D0%BF%D0%BB%D0%B0%D0%B9%D0%BD%D0%B0%D0%BC%D0%B8
            //var xtest = new double[] { 1, 2, 3, 4, 5, 6 };
            //var ytest = new double[] { 1.0002, 1.0341, 0.6, 0.40105, 0.1, 0.23975 };
            //var splinetest = cubicSpline.Solve(xtest, ytest);
            //Helpers.PrintMatrix("CubicSpline Test", splinetest);


            //double[] xwiki = new double[] { -1.0, 0.0, 3.0 };
            //double[] ywiki = new double[] { 0.5, 0.0, 3.0 };
            //var splinewiki = cubicSpline.Solve(xwiki, ywiki);
            //Helpers.PrintMatrix("CubicSpline TestWikipedia", splinewiki);
            Console.ReadKey();

        }
    }
}
