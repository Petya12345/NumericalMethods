using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Algorithms
{
    class LSQ
    {
        public double[] Solve(double[] X, double[] Y)
        {
            //step 1: create matrix, let Z - matrix coefficients
            var k = X.Length; //???

            Console.WriteLine("LSQ Polinomial Method with order {0}", k);

            //x for matrix
            var z = new double[k, k];
            //y for matrix
            var zY = new double[k];

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    double s = 0;
                    for (int m = 0; m < X.Length; m++)
                    {
                        s += Math.Pow(X[m], i + j);
                    }
                    z[i, j] = s;
                }
                double sY = 0;
                for (int m = 0; m < X.Length; m++)
                {
                    sY += Y[m] * Math.Pow(X[m], i);
                }
                zY[i] = sY;
            }
            Helpers.PrintMatrix("A", z);
            Helpers.PrintVector("B", zY);
            //step 2: solve matrix
            Gauss.computeCoefficents(z, zY);
            return zY;
        }


    }
}
