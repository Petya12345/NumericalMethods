﻿using System;
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
