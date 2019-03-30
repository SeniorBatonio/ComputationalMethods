using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Slove();
        }

        public static void Slove()
        {
            double[][] matrixA = new double[][]
            {
                new  double[]{6.92,  1.28,  0.79, 1.15, -0.66},
                new  double[]{0.92,  3.5,  1.3, -1.62,   1.02},
                new  double[]{1.15, -2.46,  7, 2.1,    1.483},
                new  double[]{1.33, 0.16,  2.1,  5.44,  -18},
                new  double[]{1.14, -1.68, -1.217, 9,   -3 }
            };
            double[] matrixB = new double[]
            {
                2.1,
                0.72,
                3.87,
                13.8,
                -1.08
            };
            GaussMethod Solution = new GaussMethod((uint)matrixA.Length, (uint)matrixA.Length);

            //заполняем правую часть
            Solution.RightPart = matrixB;

            //заполняем матрицу
            Solution.Matrix = matrixA;

            //Console.WriteLine("----Начальная матрица----\n");
            //решаем матрицу
            Solution.SolveMatrix();
            double[] ReturnVal = new double[5];
            //сохраняем ответ
            ReturnVal = Solution.Answer;
            Console.WriteLine("----Решение----\n");
            for(int i = 0; i < ReturnVal.Length; ++i)
            {
                Console.WriteLine(ReturnVal[i]);
            }

            Console.ReadLine();

        }


    }
}
