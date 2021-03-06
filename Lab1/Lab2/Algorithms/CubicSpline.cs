﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Algorithms
{
    class CubicSpline
    {
        public double[,] Solve(double[] X, double[] Y)
        {
            Console.WriteLine("Cubic Spline Interpolation Method");
            var k = X.Length - 1;
            var result = new double[k, 4]; //4 coeff for each spline - a,b,c,d

            var h = new double[k];
            for (int i = 0; i < k; i++)
            {
                h[i] = X[i + 1] - X[i];
                //ai
                result[i, 0] = Y[i];
            }

            //matrix
            var A = new double[k - 1, k - 1]; //c1 = 0 => skip one row
            var B = new double[k - 1];
            for (int i = 1; i < k; i++)
            {
                if (i - 2 > 0) //dont calculate c1
                {
                    A[i - 1, i - 2] = h[i - 1]; //hi-1 * ci-1
                }

                A[i - 1, i - 1] = (h[i - 1] + h[i]) * 2; //2(hi-1 + hi) * ci

                if (i + 1 < k)
                {
                    A[i - 1, i] = h[i]; //hi * ci+1
                }

                B[i - 1] = 3 * ((Y[i + 1] - Y[i]) / h[i] - (Y[i] - Y[i - 1]) / h[i - 1]);
            }
            Helpers.PrintMatrix("A", A);
            Helpers.PrintVector("B", B);
            if (B.Length > 2)
            {
                //B = Thompson.Solve(A, B);

                Gauss.computeCoefficents(A, B);
            }
            else
            {
                Gauss.computeCoefficents(A, B);
            }
            for (int i = 1; i < k; i++)
            {
                result[i, 2] = B[i - 1]; //c
            }
            for (int i = 0; i < k - 1; i++)
            {
                var c = result[i, 2];

                //calculate b
                result[i, 1] = (Y[i + 1] - Y[i] - c * h[i] * h[i] - ((result[i + 1, 2] - c) / 3) * h[i] * h[i]) / h[i];
                //calculate d
                result[i, 3] = (result[i + 1, 2] - c) / (3 * h[i]);
            }
            //for last row we calculate b and d from last equation 2cn + 6dnhn = 0
            //dn = -2cn/6hn
            result[k - 1, 3] = -result[k - 1, 2] / 6 * h[k - 1];
            //bn - calculate using dn
            result[k - 1, 1] = (Y[k] - Y[k - 1] - result[k - 1, 2] * h[k - 1] * h[k - 1] - result[k - 1, 3] * h[k - 1] * h[k - 1] * h[k - 1]) / h[k - 1];
            return result;
        }
    }
}
