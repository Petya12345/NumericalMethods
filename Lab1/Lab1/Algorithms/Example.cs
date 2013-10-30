using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Algorithms
{
    //this is sample file for new algorithm implementation
    //please feel free to copy it
    class Example : IMatrixSolutionAlgorithm
    {
        public double[] Solve(double[,] A, double[] B)
        {
            //this is how to access A elements
            var a11 = A[0, 0]; //in c# array index starts with 0!

            //B elements
            var b1 = B[0];

            //create results array
            var results = new double[B.Length];

            //copy B vector to results vector (sample of for loop) {
            for (var i = 0; i < B.Length; i++)
            {
                results[i] = B[i];
            }

            //return results
            return results;
        }
    }
}
