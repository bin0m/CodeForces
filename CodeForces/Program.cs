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
            int q;
            string s = Console.ReadLine().Trim();
            q = int.Parse(s);

            var sb = new StringBuilder();
          
            for (int i = 0; i < q; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                long x = long.Parse(ss2[0]);
                long y = long.Parse(ss2[1]);
                long k = long.Parse(ss2[2]);
                long ans = GetMaxDiagonalMoves(x, y, k);
                sb.AppendLine(ans.ToString());
            }
            Console.Write(sb.ToString());
            Console.ReadLine();
        }

        static long GetMaxDiagonalMoves(long x, long y, long k)
        {
            long ans = -1;

            if (k < Math.Max(x, y))
            {
                return ans;
            }

            if ((x+y) % 2 == 0)
            {              
                if (x % 2 == 0)
                {
                    if( k % 2 == 0)
                    {
                        return k;
                    }
                    else
                    {
                        return k - 2;
                    }
                }
                else
                {
                    if (k % 2 == 0)
                    {
                        return k - 2;
                    }
                    else
                    {
                        return k;
                    }
                }
            }
            else
            {
                return k - 1;
            }
            return ans;
        }
    }
}
