using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler
{
    class Problem70
    {
        public static bool isPermutation(int num,int totientFunc)
        {
            int[] numDat = new int[10];
            int[] totientFuncDat = new int[10];

            while (num != 0)
            {
                numDat[num % 10]++;
                num /= 10;
            }

            while (totientFunc != 0)
            {
                totientFuncDat[totientFunc % 10]++;
                totientFunc /= 10;
            }

            for (int i = 0; i < numDat.Length; i++)
            {
                if (numDat[i] != totientFuncDat[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int totientFuncCalc(int[,] primeFactorization, int n)
        {
            BigInteger numerator=1, denominator=1;

            for (int i = 1; i <= primeFactorization[n, 0]; i++)
            {
                numerator *= primeFactorization[n, i]-1;
                denominator *= primeFactorization[n, i];
            }

            numerator *= n;

            return (int)(numerator / denominator);
        }

        public static void Main()
        {
            //System Diagnostics........................... 
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            //.............................................

            int[] seiveOfEranthosenes = new int[10000001];
            int[,] primeFactorization = new int[seiveOfEranthosenes.Length, 50];
            decimal ansMin = Decimal.MaxValue, totientFuncToNRatio = 0.0M;
            int totientFunc=0, nMin = 0, totientFuncnMin=0;

            for (int i = 0; i < seiveOfEranthosenes.Length; i++)
            {
                seiveOfEranthosenes[i] = i;
            }

            for (int i = 2; i < seiveOfEranthosenes.Length; i++)
            {
                if (seiveOfEranthosenes[i] != 0)
                {
                    for (int j = 2; (i * j) < seiveOfEranthosenes.Length; j++)
                    {
                        int tmp = primeFactorization[(i * j), 0];
                        primeFactorization[(i * j), tmp + 1] = i;
                        primeFactorization[(i * j), 0] += 1;

                        seiveOfEranthosenes[i * j] = 0;
                    }
                }
            }

            for (int i = seiveOfEranthosenes.Length -1; i > 2; i--)
            {
                if (seiveOfEranthosenes[i] == 0)
                {
                    totientFuncToNRatio = 1.0M;
                    for (int j = 1; j <= primeFactorization[i, 0]; j++)
                    {
                        totientFuncToNRatio *= (1.0M - (1.0M / primeFactorization[i, j]));
                    }

                    totientFunc = Convert.ToInt32(i * totientFuncToNRatio);
                    totientFuncToNRatio = 1.0m / (totientFuncToNRatio);
                    //Console.WriteLine(i + "-" + totientFuncToNRatio);
                }
                else
                {
                    totientFunc = i - 1;
                    totientFuncToNRatio = (i * 1.0M) / (i - 1);
                }

                if (isPermutation(i, totientFunc) == true)
                {
                    if (totientFuncToNRatio < ansMin)
                    {
                        ansMin = totientFuncToNRatio;
                        totientFuncnMin = totientFunc;
                        nMin = i;
                    }
                }

                //Console.WriteLine(i+"-"+totientFunc+"-"+totientFuncToNRatio);
            }

            Console.WriteLine(nMin+"----"+totientFuncnMin);

            //System Diagnostics........................... 
            watch.Stop();

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine($"Memory Used: {Convert.ToDecimal(proc.PrivateMemorySize64/(1024*1024))} MB");

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //.............................................

        }

    }
}
