using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Algorithms
{
    class Reference : IMatrixSolutionAlgorithm
    {
        public double[] Solve(double[,] A, double[] B, ref double epsilon)
        {
            double[] tmp = new double[B.Length]; //algorithm below returns data to Y array, so we create temporary variable to hold the results
            Array.Copy(B, tmp, B.Length);
            this.computeCoefficents(A, tmp);
            return tmp;
        }


        //AG: this thing I got from the internet http://social.msdn.microsoft.com/Forums/en-US/70408584-668d-49a0-b179-fabf101e71e9/solution-of-linear-equations-systems
        private void computeCoefficents2(double[,] X, double[] Y)
        {
            //Use Guassian Elimination.  I've got source code on these forums somwhere.
            //This function takes an N X N matrix in the X variable and a 1 X N vector in the Y variable.  The coefficients are returned in the Y variable.
            int I, J, K, K1, N;
            N = Y.Length;
            for (K = 0; K < N; K++)
            {
                K1 = K + 1;
                for (I = K; I < N; I++)
                {
                    if (X[I, K] != 0)
                    {
                        for (J = K1; J < N; J++)
                        {
                            X[I, J] /= X[I, K];
                        }
                        Y[I] /= X[I, K];
                    }
                }
                for (I = K1; I < N; I++)
                {
                    if (X[I, K] != 0)
                    {
                        for (J = K1; J < N; J++)
                        {
                            X[I, J] -= X[K, J];
                        }
                        Y[I] -= Y[K];
                    }
                }
            }
            for (I = N - 2; I >= 0; I--)
            {
                for (J = N - 1; J >= I + 1; J--)
                {
                    Y[I] -= X[I, J] * Y[J];
                }
            }
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
                       X[k, j] = X[k, j] * quotient + X[i, j];
                   }
                }

                //calculations from gauss method, part 2
            }
        }
    }
}

