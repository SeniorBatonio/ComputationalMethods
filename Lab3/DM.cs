using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class DM
    {
        String debugLog = "";
        double[,] A;
        double[] LambdaK;
        int n;

        public DM(List<Double> listA, int n)
        {
            this.A = new double[n,n];
            for (int i = 0; i < listA.Count; i++)
            {
                A[i / n, i % n] = listA.ElementAt(i);
            }
            debugAdd("Получение матрицы размером " + n + "x" + n + ":\n");
            debugADump();
            this.n = n;

            this.makeK();
        }

        public DM(double[,] A)
        {
            this.A = A;
            int n = (int)Math.Sqrt(A.Length);
            debugAdd("Получение матрицы размером " + n + "x" + n + ":\n");
            debugADump();
            this.n = (int)Math.Sqrt(A.Length);
            this.makeK();
        }

        private void debugAdd(String msg)
        {
            debugLog += msg;
        }

        private void debugADump()
        {
            debugLog += "A = {\n";
            for (int i = 0; i < Math.Sqrt(A.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(A.Length); j++)
                {
                    debugLog += "\t" + String.Format("{0:f6}", A[i,j]);
                }
                debugLog += "\n";
            }
            debugLog += "}\n";
        }

        private void debugMDump(double[,] M)
        {
            debugLog += "M = {\n";
            for (int i = 0; i < Math.Sqrt(M.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(M.Length); j++)
                {
                    debugLog += "\t" + String.Format("{0:f6}", M[i, j]);
                }
                debugLog += "\n";
            }
            debugLog += "}\n";
        }

        private void debugM1Dump(double[,] M)
        {
            debugLog += "M-1 = {\n";
            for (int i = 0; i < Math.Sqrt(M.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(M.Length); j++)
                {
                    debugLog += "\t" + String.Format("{0:f6}", M[i, j]);
                }
                debugLog += "\n";
            }
            debugLog += "}\n";
        }
        private void debugDump(double[] X)
        {
            debugLog += "[";
            int xn = X.Length;
            for (int i = 0; i < xn; i++)
            {
                if (i > 0) debugLog += " ";
                debugLog += X[i];
            }
            debugLog += "]";
        }

        private bool step(int k)
        {
            debugAdd("Выполняем шаг " + (Math.Sqrt(A.Length) - k - 1) + ".\n");
            bool enable = true;
            if (this.A[k + 1,k] == 0)
            {
                // Find A[index] != 0
                int index = k - 1;
                while (index >= 0 && this.A[k + 1, index] == 0)
                    index--;
                if (index < 0)
                {
                    enable = false;
                    double[,] D_ = new double[k + 1, k + 1];
                    double[,] D__ = new double[n - k - 1, n - k - 1];
                    for (int i = 0; i < k + 1; i++)
                    {
                        for (int j = 0; j < k + 1; j++)
                        {
                            D_[i,j] = this.A[i, j];
                        }
                    }
                    for (int i = k + 1; i < n; i++)
                    {
                        for (int j = k + 1; j < n; j++)
                        {
                            D__[i - k - 1, j - k - 1] = this.A[i, j];
                        }
                    }
                    double[] D__K = this.makeLambda(D__);
                    DM DanContinue = new DM(D_);
                    debugAdd(DanContinue.getDebug());
                    this.LambdaK = this.multiplyPol(DanContinue.getKLambda(), D__K);
                }
                else
                {
                    debugAdd("Переставляем строки и столбцы " + index + " и " + k + ". Получаем матрицу:\n");
                    for (int l = 0; l < n; l++)
                    {
                        double t = this.A[l, k];
                        this.A[l, k] = this.A[l, index];
                        this.A[l, index] = t;
                    }
                    for (int l = 0; l < n; l++)
                    {
                        double t = this.A[k, l];
                        this.A[k, l] = this.A[index, l];
                        this.A[index, l] = t;
                    }
                    debugADump();
                }
            }

            if (enable)
            {
                double[,] M = identityMatrix(), rM = identityMatrix();
                for (int j = 0; j < n; j++)
                {
                    if (j == k)
                    {
                        M[k,j] = 1.0/ this.A[k + 1, k];
                    }
                    else
                    {
                        M[k,j] = -this.A[k + 1, j] / this.A[k + 1, k];
                    }
                    rM[k,j] = this.A[k + 1, j];
                }
                debugMDump(M);
                debugM1Dump(rM);
                this.A = multiplyMatrix(rM, this.A);
                this.A = multiplyMatrix(this.A, M);
            }
            debugAdd("После выполнения шага получаем следующую матрицу:\n");
            debugADump();
            return enable;
        }

        private void makeK()
        {
            int k = this.n - 2;
            debugAdd("Начинаем построение матрицы Фробениуса (количество итераций: " + (k + 1) + ").\n");
            bool cont = true;
            for (; k >= 0; k--)
            {
                cont = this.step(k);
                if (!cont)
                {
                    debugAdd("Процесс построения матрицы Фробениуса прерван.\n");
                    break;
                }
            }
            debugAdd("Процесс построения матрицы Фробениуса закончен. \n");
            if (cont)
            {
                this.LambdaK = this.makeLambda(A);
            }
        }

        private double[,] identityMatrix()
        {
            double[, ] I = new double[n, n];
            for (int k = 0; k < n; k++)
                I[k, k] = 1;
            return I;
        }

        private double[,] multiplyMatrix(double[,] X, double[,] Y)
        {
            double[,] Z = new double[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Z[i,j] = 0;
                    for (int k = 0; k < n; k++)
                        Z[i,j] += X[i,k] * Y[k,j];
                }
            }
            return Z;
        }

        public String formatTex(bool reverse)
        {
            String tex = "";
            int kn = LambdaK.Length;
            if (reverse)
            {
                for (int i = kn - 1; i >= 0; i--)
                {
                    if (i < kn - 1 && LambdaK[i] > 0) tex += " + ";
                    else if (LambdaK[i] < 0) tex += " - ";
                    if (LambdaK[i] != 0)
                    {
                        double abs = Math.Abs(LambdaK[i]);
                        tex += (abs == 1 && i > 0 ? "" : String.Format("{0:f6}", abs)) + (i > 0 ? "\\lambda" +
                                (i != 1 ? "^" + i : "") : "");
                    }
                }
            }
            else
            {
                for (int i = 0; i < kn; i++)
                {
                    if (i > 0 && LambdaK[i] > 0) tex += " + ";
                    else if (LambdaK[i] < 0) tex += " - ";
                    if (LambdaK[i] != 0)
                    {
                        double abs = Math.Abs(LambdaK[i]);
                        tex += (abs == 1 && i > 0 ? "" : String.Format("{0:f6}", abs)) + (i > 0 ? "\\lambda" +
                                (i != 1 ? "^" + i : "") : "");
                    }
                }
            }
            return tex;
        }

        private double[] multiplyPol(double[] P, double[] Q)
        {
            debugAdd("Находим произведение полиномов ");
            debugDump(P);
            debugAdd(" * ");
            debugDump(Q);
            debugAdd(" = ");
            int size = P.Length + Q.Length - 1;
            double[] S = new double[size];
            for (int i = 0; i < P.Length; i++)
            {
                for (int j = 0; j < Q.Length; j++)
                {
                    S[i + j] += P[i] * Q[j];
                }
            }
            debugDump(S);
            debugAdd("\n");
            return S;
        }

        private double[] makeLambda(double[,] M)
        {
            int size = (int)Math.Sqrt(M.Length) + 1;
            int n = (int)Math.Sqrt(M.Length);
            double[] LM = new double[size];
            int k = (int)Math.Sqrt(M.Length) % 2 == 0 ? 1 : -1;
            for (int i = n; i > 0; i--)
            {
                LM[n - i] = -k * M[0, i - 1];
            }
            LM[n] = k;
            return LM;
        }

        public double[,] getA()
        {
            return this.A;
        }
        public double[] getKLambda() { return this.LambdaK; }

        public String toString() { return formatTex(false); }

        public String getDebug() { return debugLog + "\n"; }
    }
}
