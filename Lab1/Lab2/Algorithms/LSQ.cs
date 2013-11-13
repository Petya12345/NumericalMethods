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

            //step 2: solve matrix
            computeCoefficents(z, zY);
            return zY;
        }


        private void computeCoefficents(double[,] X, double[] Y)
        {
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
    }
}
