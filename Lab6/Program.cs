using System;
using MathNet.Numerics.Integration;

namespace Lab6
{
    class Program
    {
        static double a = 1.4;
        static double b = 2.1;
        public static double f(double x) { return ((x+1)*Math.Sin(x)); }
        public static double I(double a, double b, int n, double y) { return ((b - a) / (2 * n) * y); }

        static void Main(string[] args)
        {
            Console.WriteLine("----Trapeze Method----");
            Console.WriteLine(TrapezeMethod());
            Console.WriteLine();
            Console.WriteLine("----Gauss Method----");
            var result = GaussLegendreRule.Integrate(x => f(x) , a, b, 100);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static double TrapezeMethod()
        {
            int n; double dy, In, y = 0;
            n = 100;
            if (n > 1) {
                dy = (b - a) / n;
                y += f(a) + f(b);
                for (int i = 1; i < n; i++) { y += 2 * (f(a + dy * i));
                }
                In = I(a, b, n, y);
                return In;
            }
            else { throw new ArgumentException("n can`t be less then zero!", nameof(n)); }
        }
    }
}
