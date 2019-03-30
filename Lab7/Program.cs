using System;

namespace Lab7
{
    class Program
    {
        static double X0 = 0;
        static double X = 1;
        static double Y0 = 0.1;
        static double H = 0.1;

        static void Main(string[] args)
        {
            Console.WriteLine("----Runge-Kutt Method----");
            RungeKuttSlover();
            Console.WriteLine();
            Console.WriteLine("----Adams Method----");
            AdamsSlover();
            Console.ReadLine();
        }

        private static double f(double x1, double y1)
        {
            return (1 - Math.Sin(2.2 * x1 + y1) + (3.4 * y1 / (2 + x1)));
        }

        static void RungeKuttSlover()
        {
            double x0 = X0, x = X, h = H, y0 = Y0;
            // Count number of iterations using 
            // step size or step height h 
            int n = (int)((x - x0) / h);

            double k1, k2, k3, k4;

            // Iterate for number of iterations 
            double y = y0;

            for (int i = 1; i <= n; i++)
            {

                // Apply Runge Kutta Formulas 
                // to find next value of y 
                k1 = h * (f(x0, y));

                k2 = h * (f(x0 + 0.5 * h,
                                 y + 0.5 * k1));

                k3 = h * (f(x0 + 0.5 * h,
                                y + 0.5 * k2));

                k4 = h * (f(x0 + h, y + k3));

                // Update next value of y 
                y = y + (1.0 / 6.0) * (k1 + 2
                           * k2 + 2 * k3 + k4);

                // Update next value of x 
                x0 = x0 + h;
                Console.WriteLine("At time " + x0 + " the solution = " + y);
            }
        }

        static void AdamsSlover()
        {
            double A, B, ALPHA, H, T, K1, K2, K3, K4;
            double[] W = new double[100];
            int I, N;

            A = X0;
            B = X;
            N = (int)((B - A) / Program.H);
            /* STEP 1 */
            H = Program.H;
            T = A;
            W[0] = 0.1; // initial value

            /* STEP 2 --- Use order 4 RK method to get w1, w2, w3 */
            /// NOTE: The "for" loop starts with I = 1. 
            for (I = 1; I <= 3; I++)
            {
                /* STEP 3 */
                /* Compute K1, K2 RESP. */
                K1 = H * f(T, W[I - 1]);
                K2 = H * f(T + H / 2.0, W[I - 1] + K1 / 2.0);
                K3 = H * f(T + H / 2.0, W[I - 1] + K2 / 2.0);
                K4 = H * f(T + H, W[I - 1] + K3);

                /* STEP 4 */
                /* COMPUTE W(I) */
                W[I] = W[I - 1] + 1 / 6.0 * (K1 + 2.0 * K2 + 2.0 * K3 + K4);

                /* COMPUTE T(I) */
                T = A + I * H;

                /* STEP 5 */
                Console.WriteLine("At time " + T + " the solution = " + W[I]);
            }

            /* STEP 6---Use Adam-Bashforth 4-step explicit method */
            for (I = 4; I <= N; I++)
            {
                K1 = 55.0 * f(T, W[I - 1]) - 59.0 * f(T - H, W[I - 2]) + 37.0 * f(T - 2.0 * H, W[I - 3]) - 9.0 * f(T - 3.0 * H, W[I - 4]);
                W[I] = W[I - 1] + H / 24.0 * K1;

                /* COMPUTE T(I) */
                T = A + I * H;

                /* STEP 7 */
                Console.WriteLine("At time " + T + " the solution = " + W[I]);
            }

        }

    }
}
