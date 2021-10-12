using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    class Problem71
    {
        public static void Main()
        {
            //System Diagnostics........................... 
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            //.............................................

            //https://www.mathblog.dk/project-euler-71-proper-fractions-ascending-order/

            long a = 3, b = 7, p, r = 0, s = 1;

            for (long q = 1000000; q >= 2; q--)
            {
                p = (a * q - 1) / b;

                if (r * q < p * s)
                {
                    r = p;
                    s = q;
                }
            }

            Console.WriteLine(r + "/" + s);
            //System Diagnostics........................... 
            watch.Stop();

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine($"Memory Used: {Convert.ToDecimal(proc.PrivateMemorySize64 / (1024 * 1024))} MB");

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //.............................................
        }
    }
}
