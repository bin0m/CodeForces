using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class Program
    {
        static void Main(string[] args)
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int j = 0; j < t; j++)
            {
                s = Console.ReadLine().Trim();
                long n = long.Parse(s);
                long sum = 0;
                for (long i = n - 1; i > 0; i = i - 2)
                {
                    sum = sum + i * 2 * i;
                }

                Console.WriteLine(sum);
            }
        }      
    }
}
