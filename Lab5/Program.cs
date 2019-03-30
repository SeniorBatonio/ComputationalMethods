using System;

namespace Lab5
{
    internal class Program
    {
        private static double Func(double x)
        {
            return 9 * Math.Pow(x, 5) + 3 * Math.Pow(x, 2) - 2 * x - 1;
        }

        private static double DerivativeFunc(double x)
        {
            return 45 * Math.Pow(x, 4) + 6 * x - 2;
        }

        private static void Main(string[] args)
        {
            double a = 0.5, b = 0.7;
            double exp = Math.Pow(10, -6);
            Console.WriteLine("----Newton----");
            Console.WriteLine("x = " + Newton(a, exp, 0));
            Console.WriteLine("----Bisection----");
            Console.WriteLine("x = " + Bisection(a, b, exp, 0));
            Console.WriteLine("----Chord----");
            Console.WriteLine("x = " + method_chord(a,b,exp));
            Console.ReadLine();
        }

        private static double Newton(double x, double eps, int i)
        {
            Console.WriteLine(i + "Newton");
            i++;
            double y = x;
            x = x - Func(x) / DerivativeFunc(x);
            return Math.Abs(y - x) >= eps ? Newton(x, eps, i) : x;
        }

        private static double Bisection(double a, double b, double eps, int i)
        {
            i++;
            Console.WriteLine(i + "Bisection");
            double c = (a + b) / 2;
            if (Func(a) * Func(c) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
            return (Math.Abs(b - a) > eps && Func(c) != 0) ? Bisection(a,b,eps, i) : c;
        }

        private static double method_chord(double x_prev, double x_curr, double e)
        {
            double xNext = 0;
            int i = 0;
            do
            {
                double tmp = xNext;
                xNext = x_curr - Program.Func(x_curr) * (x_prev - x_curr) / (Program.Func(x_prev) - Program.Func(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
                i++;
            } while (Math.Abs(xNext - x_curr) > e);

            Console.WriteLine("Chord" + i);
            return xNext;
        }
    }
}
