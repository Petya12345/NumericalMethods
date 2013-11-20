using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Algorithms
{
    class Thompson
    {
        public static double[] Solve(double[,] A, double[] B)
        {
            if (B.Length == 1)
            {
                return new double[] { B[0] / A[0, 0] };
            }
            var result = new double[B.Length];
            var Alpha = new double[result.Length];
            var Beta = new double[result.Length];
            Alpha[0] = A[0, 1] / A[0, 0];
            Beta[0] = B[0] / A[0, 0];

            for (int i = 1; i < result.Length; i++)
            {
                if (i < result.Length - 1)
                    Alpha[i] = A[i, i + 1] / (A[i, i] - Alpha[i - 1] * A[i, i - 1]);
                Beta[i] = (B[i] - A[i, i - 1] * Beta[i - 1]) / (A[i, i] - Alpha[i - 1] * A[i, i - 1]);
            }

            result[result.Length - 1] = Beta[Beta.Length - 1];

            for (int i = result.Length - 2; i >= 0; i--)
            {
                result[i] = Beta[i] - Alpha[i] * result[i + 1];
            }

            return result;
        }
    }
}
