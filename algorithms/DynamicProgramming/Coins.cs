using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DynamicProgramming
{
    class Coins
    {
        public int GetMinCoins(int[] coins, int sum)
        {
            if (sum < 0 || coins == null || coins.Length == 0)
                return 0;
            var len = coins.Length;
            int[,] a = new int[sum,len];
            for (int i = 0; i < sum; i++)
                a[i, 0] = int.MaxValue;
            for(int i=1; i<sum; i++)
            {
                for(int j=0; j<len; j++)
                {
                    if (i >= coins[j])
                    {
                        int val = 0;
                        if (i - coins[j] >= 0)
                            val = a[i, j - 1] > a[i - coins[j], j - 1] ? a[i - coins[j], j - 1] : a[i, j - 1];
                        else
                            val = int.MaxValue;
                        a[i, j] = val;
                    }
                    else
                        a[i, j] = int.MaxValue;
                }
            }

            Console.WriteLine("Output: ");
            for(int i=0; i<sum; i++)
            {
                for (int j = 0; j < len; j++)
                    Console.Write(a[i, j] + "  ");
                Console.WriteLine();
            }
            Console.ReadLine();
            return 0;
        } 
    }
}
