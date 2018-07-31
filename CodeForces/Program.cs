using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            long m;
            string s = Console.ReadLine().Trim();
            var ss = s.Split(' ');
            n = int.Parse(ss[0]);
            m = int.Parse(ss[1]);

            long[] diffs = new long[n];
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                long a = int.Parse(ss2[0]);
                long b = int.Parse(ss2[1]);
                sum += a;
                diffs[i] = a - b;
            }
            int songsToArchive = 0;
            if (sum > m)
            {
                Array.Sort(diffs);

                while (songsToArchive < n)
                {
                    sum -= diffs[n - songsToArchive - 1];
                    songsToArchive++;
                    if (sum <= m)
                    {
                        break;
                    }
                }
                if (sum > m)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }


            Console.WriteLine(songsToArchive);

        }
    }
}
