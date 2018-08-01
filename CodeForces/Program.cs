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
            long n;
            int k;
            long s;
            string str = Console.ReadLine().Trim();
            var ss = str.Split(' ');
            n = long.Parse(ss[0]);
            k = int.Parse(ss[1]);
            s = long.Parse(ss[2]);

            long maxStep = n - 1;
            if (!(s >= k && s <= maxStep * k))
            {
                Console.WriteLine("NO");
                return;
            }

            Console.WriteLine("YES");
            var sb = new StringBuilder();
            long currentHouse = 1;

            // 1st Phase: max steps
            long nextS = s - maxStep;
            while (nextS >= (k - 1) && k > 0)
            {
                if (currentHouse == 1)
                {
                    currentHouse = n;
                }
                else if (currentHouse == n)
                {
                    currentHouse = 1;
                }
                sb.Append(currentHouse).Append(' ');
                s = nextS;
                nextS = s - maxStep;
                k--;
            }
            if (k == 0)
            {
                //terminate
                Console.WriteLine(sb.ToString());
                return;
            }

            // 2 phase: single mid step
            var midStep = (s - (k - 1));
            if (currentHouse == 1)
            {
                currentHouse += midStep;
            }
            else if (currentHouse == n)
            {
                currentHouse -= midStep;
            }
            sb.Append(currentHouse).Append(' ');
            k--;


            // 3st phase: 1 steps
            while (k > 0)
            {
                if (currentHouse == 1)
                {
                    currentHouse++;
                }
                else if (currentHouse > 1)
                {
                    currentHouse--;
                }

                sb.Append(currentHouse).Append(' ');
                k--;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
