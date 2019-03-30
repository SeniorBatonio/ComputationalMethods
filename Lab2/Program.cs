using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] matrixA = new double[][]
            {
                new double[]{6.59, 1.28, 0.79, -0.21, 1.195 },
                new double[]{0.92, 3.83, 1.3, 1.02, -1.63},
                new double[]{1.15, -2.46, 5.77, 1.483, 2.1},
                new double[]{1.285, 0.16, 2.1, -18, 5.77},
                new double[]{0.69, -1.68, -1.217, -6, 9 }
            };

            double[] matrixB = new double[]
            {
                2.1,
                0.36,
                3.89,
                11.04,
                -0.27
            };

            SimpleIterMethod.Slove(matrixA, matrixB, matrixB.Length);
            Console.ReadLine();

        }
    }
}
