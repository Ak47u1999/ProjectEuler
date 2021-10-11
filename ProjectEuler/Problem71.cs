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

            //Farey's Sequence (Use Stern brocot tree)

            int n = 100, a = 0, b = 1, c = 1, d = n, p, q;
            BigInteger totalTerms = 1;
            decimal temp;

            while (true)
            {
                temp = (n + b) / d;
                p = Convert.ToInt32(Math.Floor(temp)) * c - a;

                q = Convert.ToInt32(Math.Floor(temp)) * d - b;

                totalTerms++;
                if (p == 3 && q == 7)
                {
                    Console.WriteLine(c + "/" + d+" totalterms: "+totalTerms);
                    break;
                }

                a = c;b = d;
                c = p;d = q;
            }


            //System Diagnostics........................... 
            watch.Stop();

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine($"Memory Used: {Convert.ToDecimal(proc.PrivateMemorySize64 / (1024 * 1024))} MB");

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //.............................................
        }
    }
}
