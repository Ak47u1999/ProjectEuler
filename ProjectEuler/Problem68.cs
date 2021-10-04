using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    class Problem68
    {
        public static class global
        {
           public static int[] numbers = new int[10];
           public static int[] fiveGon = new int[17];
        }

        public static void Main()
        {

            for (int i = 0; i < global.numbers.Length; i++)
            {
                global.numbers[i] = i;
            }
            global.numbers[0] = 10;

        }
    }
}
