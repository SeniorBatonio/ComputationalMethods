using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            DM method = new DM(new double[,]
            {
                {7.14, 1.26, 0.81, 1.12 },
                {1.26, 3.28, 1.30, 0.16 },
                {0.81, 1.30, 6.32, 2.10 },
                {1.12, 0.16, 2.10, 5.22 }
            });
            Console.WriteLine(method.getDebug());
            Console.WriteLine(method.toString());
            Console.ReadLine();
        }
    }
}
