using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Algorithms
{
    class Gauss : IMatrixSolutionAlgorithm
    {
        public double[] Solve(double[,] A, double[] B, ref double epsilon)
        {
            double[] tmp = new double[B.Length]; //algorithm below returns data to Y array, so we create temporary variable to hold the results
            Array.Copy(B, tmp, B.Length);
            this.computeCoefficents(A, tmp);
            return tmp;
        }

        private void computeCoefficents(double[,] X, double[] Y)
        {
            int n = Y.Length, exchangeI;
            double max, swap, quotient;

            for (int k = 0; k < n-1; k++ )
            {
                //choosing of leading element
                max = X[k, k];
                exchangeI = k;
                for (int i = k+1; i < n; i++ )
                {
                    if (X[i, k] > max)
                    {
                        max = X[i, k];
                        exchangeI = i;
                    }
                }

                //exchange k and i rows
                if (k != exchangeI)
                {
                    for (int j = k; j < n; j++ )
                    {
                        swap = X[k, j];
                        X[k, j] = X[exchangeI, j];
                        X[exchangeI, j] = swap;

                    }
                }

                //calculations from gauss method, part 1
                for (int i = k+1; i < n; i++) 
                {
                   quotient = X[i, k] / X[k, k] * (-1);
                   for (int j = k; j < n; j++ )
                   {
                       X[i, j] = X[k, j] * quotient + X[i, j];
                   }
                   Y[i] = Y[k] * quotient + Y[i];
                }

                //calculations from gauss method, part 2
            }
            Y[n-1] = Y[n-1] / X[n-1, n-1];
            double sum;
            for (int k = n-2; k >= 0; k-- )
            {
                sum = 0;
                for (int i = 1; i < n - k; i++) 
                {
                    sum += X[k, n - i] * Y[n - i];
                }
                Y [k] = (Y[k] - sum) / X[k, k];
            }
        }
    }
}

