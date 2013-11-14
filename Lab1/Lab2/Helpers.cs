using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Helpers
    {
        public static void PrintMatrix(string name, double[,] matrix)
        {
            Console.WriteLine("===MATRIX {0}===", name);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintVector(string name, double[] vector)
        {
            Console.WriteLine("===VECTOR {0}===", name);
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write("{0}\t", vector[i]);
            }
            Console.WriteLine();
        }

        public static double[,] InterpolateSimplePolinoma(double[] coeffs, double xMin, double xMax, double step)
        {
            var numberOfPoints = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            var result = new double[numberOfPoints, 2];
            for (int i = 0; i < numberOfPoints; i++)
            {
                var x = xMin + step * i;
                var curr = 0D;
                for (int j = 0; j < coeffs.Length; j++)
                {
                    curr += coeffs[j] * Math.Pow(x, j);
                }
                result[i, 0] = x;
                result[i, 1] = curr;
            }
            return result;
        }

        public static double[,] InterpolateQubicSplines(double[,] splineCoeffs, double xMin, double xMax, double step, double[] Xsrc)
        {
            var numberOfPoints = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            var result = new double[numberOfPoints, 2];
            for (int i = 0; i < numberOfPoints; i++)
            {
                var x = xMin + step * i;
                var splineIndex = getSplineIndex(splineCoeffs, x, Xsrc);
                result[i, 0] = x;
                result[i, 1] =
                    splineCoeffs[splineIndex, 0]
                    + splineCoeffs[splineIndex, 1] * (x - Xsrc[splineIndex])
                    + splineCoeffs[splineIndex, 2] * Math.Pow(x - Xsrc[splineIndex], 2)
                    + splineCoeffs[splineIndex, 3] * Math.Pow(x - Xsrc[splineIndex], 3);
            }
            return result;
        }

        static int getSplineIndex(double[,] splineCoeffs, double x, double[] Xsrc)
        {
            var splineCoeffLastIndex = splineCoeffs.GetLength(0) - 1;
            if (x <= Xsrc[0]) return 0; //use first spline
            if (x >= Xsrc[Xsrc.Length - 1]) return splineCoeffLastIndex;
            for (int i = 0; i < Xsrc.Length - 2; i++)
            {
                if (x >= Xsrc[i] && x <= Xsrc[i + 1])
                {
                    return i;
                }
            }
            return splineCoeffLastIndex;
        }
    }
}
