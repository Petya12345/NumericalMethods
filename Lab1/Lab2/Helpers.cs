using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Helpers
    {
        public static void PrintMatrix(string name, double[,] matrix)
        {
            Console.WriteLine("===MATRIX {0}===", name);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void printVector(string name, double[] vector)
        {
            Console.WriteLine("===VECTOR {0}===", name);
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write("{0}\t", vector[i]);
            }
            Console.WriteLine();
        }
    }
}
