using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Algorithms
{
    class Relax : IMatrixSolutionAlgorithm
    {
        public double[] Solve(double[,] A, double[] B, ref double epsilon)
        {
            var omega = 1; //relaxation 
            int n = B.Length;
            var x = new double[n];
            var xPrev = new double[n];
            do
            {
                Array.Copy(x, xPrev, n);
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n && j != i; j++)
                    {
                        sum += A[i, j] * x[j];
                    }

                    var xZeidel = (B[i] - sum) / A[i, i];
                    x[i] = xPrev[i] + omega * (xZeidel - xPrev[i]);
                }
            }
            while (!isFinished(x, xPrev, epsilon));
            return x;
        }

        private bool isFinished(double[] x, double[] xPrev, double epsilon)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (Math.Abs(x[i] - xPrev[i]) > epsilon) return false;
            }
            return true;
        }
    }
}
