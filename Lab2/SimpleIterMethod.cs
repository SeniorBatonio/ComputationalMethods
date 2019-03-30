using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2
{
    public static class SimpleIterMethod
    {
        

        static public void Slove(double[][] a, double[] b, int N)
        {
            double E;
            double[] x0 = new double[5] { 0, 0, 0, 0, 0 };
            double[] x = new double[5] { 0, 0, 0, 0, 0 };
            double[] delta = new double[5] { 0, 0, 0, 0, 0 };
            double[] nev = new double[5] { 0, 0, 0, 0, 0 };
            int k = 0;
            do
            {
                x[0] = (b[0] - a[0][1] * x0[1] - a[0][2] * x0[2] - a[0][3] * x0[3] - a[0][4] * x0[4]) / a[0][0];
                x[1] = (b[1] - a[1][0] * x0[0] - a[1][2] * x0[2] - a[1][3] * x0[3] - a[1][4] * x0[4]) / a[1][1];
                x[2] = (b[2] - a[2][0] * x0[0] - a[2][1] * x0[1] - a[2][3] * x0[3] - a[2][4] * x0[4]) / a[2][2];
                x[3] = (b[3] - a[3][0] * x0[0] - a[3][1] * x0[1] - a[3][2] * x0[2] - a[3][4] * x0[4]) / a[3][3];
                x[4] = (b[4] - a[4][0] * x0[0] - a[4][1] * x0[1] - a[4][2] * x0[2] - a[4][3] * x0[3]) / a[4][4];
                for (int i = 0; i < N; i++)
                {
                    delta[i] = Math.Abs(x[i] - x0[i]);
                }
                E = delta.Max();
                Console.WriteLine($"----Промежуточный результат----{k}");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(x[i]);
                    x0[i] = x[i];
                }
                Console.WriteLine();

                nev[0] = a[0][0] * x[0] + a[0][1] * x0[1] + a[0][2] * x0[2] + a[0][3] * x0[3] + a[0][4] * x0[4] - b[0];
                nev[1] = a[1][1] * x[1] + a[1][0] * x0[0] + a[1][2] * x0[2] + a[1][3] * x0[3] + a[1][4] * x0[4] - b[1];
                nev[2] = a[2][2] * x[2] + a[2][0] * x0[0] + a[2][1] * x0[1] + a[2][3] * x0[3] + a[2][4] * x0[4] - b[2];
                nev[3] = a[3][3] * x[3] + a[3][0] * x0[0] + a[3][1] * x0[1] + a[3][2] * x0[2] + a[3][4] * x0[4] - b[3];
                nev[4] = a[4][4] * x[4] + a[4][0] * x0[0] + a[4][1] * x0[1] + a[4][2] * x0[2] + a[4][3] * x0[3] - b[4];

                Console.WriteLine("----Вектор невязки----");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(nev[i]);
                }
                Console.WriteLine();
                k++;
            } while (E >= 0.000001);
            Console.WriteLine("----Конечний результат----");
            for (int j = 0; j < N; j++)
                Console.WriteLine(x[j]);
        }

    }
}
