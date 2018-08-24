using System;
using System.Linq;

namespace CodeForces
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            s = Console.ReadLine();
            int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
            if(n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            int maxSubSetLength = 1;
            int currentSubSetLength = 1;
            for (int i = 1; i < n; i++)
            {
               if(a[i] <= a[i-1] * 2)
               {
                    currentSubSetLength++;
               }
               else
               {
                    maxSubSetLength = Math.Max(maxSubSetLength, currentSubSetLength);
                    currentSubSetLength = 1;
               }
            }
            Console.WriteLine(Math.Max(maxSubSetLength, currentSubSetLength));

            Console.ReadLine();
        }
    }
}
