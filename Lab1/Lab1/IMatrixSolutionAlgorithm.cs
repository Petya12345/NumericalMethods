using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public interface IMatrixSolutionAlgorithm
    {
        double[] Solve(double[,] A, double[] B);
    }
}
