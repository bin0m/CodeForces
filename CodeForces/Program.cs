using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    // hint #1: if see in example output number > 10^9 => use long

    class Program
    {
        static void Main(string[] args)
        {

            int a = 123456789;
            int b = 100;

            int c = a * b;
            long c2 = (long)a * b;

            Console.WriteLine(c);
            Console.WriteLine(c2);

            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int j = 0; j < t; j++)
            {
                s = Console.ReadLine().Trim();
                int n = int.Parse(s);
                long sum = 0;
                for (int i = n - 1; i > 0; i = i - 2)
                {
                    sum += (long) i * 2 * i;
                }

                Console.WriteLine(sum);
            }
        }      
    }
}
