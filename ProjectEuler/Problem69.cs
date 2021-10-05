using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    class Problem69
    {

        public static void tryOne()
        {

            //for (int i = 2; i < seiveOfEranthosenesModified.Length; i++)
            //{
            //    if (seiveOfEranthosenes[i] != 0)
            //    {
            //        ans = (i * 1.0) / (i - 1);
            //        //updateIfHighest(ref ans, ref ansMax, ref nMax);
            //    }
            //    else
            //    {
            //        n = 1;

            //        for (int c = 0; c <= i; c++)
            //        {
            //            seiveOfEranthosenesModified[c] = c;
            //        }

            //        for (int j = 2; j < i; j++)
            //        {
            //            if (seiveOfEranthosenesModified[j] != 0)
            //            {
            //                if (Convert.ToDouble((i / j)) == Convert.ToDouble((i * 1.0) / j))
            //                {
            //                    //Console.WriteLine(i + "Im Here" + j);
            //                    for (int k = 1; j * k < i; k++)
            //                    {
            //                        seiveOfEranthosenesModified[j * k] = 0;
            //                    }
            //                }
            //                else
            //                    n++;
            //            }
            //        }

            //        ans = (i * 1.0) / n;
            //    }

            //    //Console.WriteLine(i+"-"+ans);
            //}
        }

        public static void tryTwo()
        {
            // for (int i = 2; i < seiveOfEranthosenes.Length; i++)
            // {
            //     Console.Write(i+"\r");
            //     if (seiveOfEranthosenes[i] != 0)
            //     {
            //         ans = (i * 1.0) / (i - 1);
            //         //updateIfHighest(ref ans, ref ansMax, ref nMax);
            //     }
            //     else
            //     {
            //         totientFunc = 0.0;

            //         for (int j = 2; j < i; j++)
            //         {
            //             if (seiveOfEranthosenes[j] != 0 && i % j == 0)
            //             {
            //                 decimal tmp = Convert.ToDecimal((i - 1) - j);
            //                 tmp = tmp / j;
            //                 totientFunc += Convert.ToDouble(Math.Ceiling(tmp));
            //             }
            //         }

            //         totientFunc = 1.0 + (i - 2) * 1.0 - totientFunc;
            //         ans = (i * 1.0) / totientFunc;
            //     }

            //     //Console.WriteLine(i + " " + ans);
            // }

        }

        public static void Main()
        {
            //System Diagnostics........................... 
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            //.............................................

            int[] seiveOfEranthosenes = new int[1000001];
            int[,] primeFactorization = new int[1000001, 50];
            double ans,ansMax=-100,totientFunc=0.0;
            int nMax=0,n=1;

            for (int i = 0; i < seiveOfEranthosenes.Length; i++)
            {
                seiveOfEranthosenes[i] = i;
            }

            for (int i = 2; i < seiveOfEranthosenes.Length; i++)
            {
                if (seiveOfEranthosenes[i] !=0)
                {
                    for (int j = 2; (i * j) < seiveOfEranthosenes.Length; j++)
                    {
                        int tmp = primeFactorization[(i * j), 0];
                        primeFactorization[(i * j), tmp+1] = i;
                        primeFactorization[(i * j), 0]+=1;

                        seiveOfEranthosenes[i * j] = 0;
                    }
                }
            }

            for (int i = 0; i <= primeFactorization[56898,0]; i++)
            {
                Console.WriteLine(primeFactorization[56898,i]);
            }


            //System Diagnostics........................... 
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //.............................................

        }
    }
}
