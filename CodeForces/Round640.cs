using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    public class Round640
    {
        // input:
        // 5070
        public static void A_SumOfRoundNumbers()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            for (int i = 0; i < n; i++)
            {
                string s2 = Console.ReadLine().Trim();
                int a = int.Parse(s2);
                var list = new List<int>();
                int q = 1;
                while (a > 0)
                {
                    if (a % 10 != 0)
                    {
                        int mod = a % 10;
                        list.Add(mod * q);
                    }
                    q *= 10;
                    a /= 10;
                }
                Console.WriteLine(list.Count);
                Console.WriteLine(PrintList(list));
            }
        }

        private static string PrintList(List<int> list)
        {
            var sb = new StringBuilder();
            foreach (int a in list)
            {
                sb.Append(a);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        // 10 3
        public static void B_SameParitySummands()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int i = 0; i < t; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int n = int.Parse(ss2[0]);
                int k = int.Parse(ss2[1]);
                if (n < k)
                {
                    Console.WriteLine("NO");
                    continue;
                }

                // try uneven
                int remainder = n - (k - 1);
                if (remainder % 2 == 1)
                {
                    var list = Enumerable.Repeat(1, k - 1).ToList();
                    list.Add(remainder);
                    Console.WriteLine("YES");
                    Console.WriteLine(PrintList(list));
                    continue;
                }

                // try even
                remainder = n - (k - 1) * 2;
                if (remainder > 0 && remainder % 2 == 0)
                {
                    var summands = Enumerable.Repeat(2, k - 1).ToList();
                    summands.Add(remainder);
                    Console.WriteLine("YES");
                    Console.WriteLine(PrintList(summands));
                    continue;
                }

                Console.WriteLine("NO");
            }
        }

        // 3 7
        public static void C_KthNotDivisibleByN()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            /*
              n = 4
              k = 12
              12 / 3


               1 2 3
               5 6 7
               9 10 11
              13 14 15
              */

            for (int i = 0; i < t; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int n = int.Parse(ss2[0]);
                int k = int.Parse(ss2[1]);

                int remainder = k % (n - 1);
                int repeats = k / (n - 1);
                int ans = repeats * n + remainder;
                if (remainder == 0)
                {
                    ans--;
                }
                Console.WriteLine(ans);
            }
        }

        // 11
        // 3 1 4 1 5 9 2 6 5 3 5
        public static void D_AliceBobAndCandies()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);
            for (int ti = 0; ti < t; ti++)
            {
                int n;
                string s2 = Console.ReadLine().Trim();
                n = int.Parse(s2);

                s = Console.ReadLine();
                int[] arr = (from v in s.Split(' ') select int.Parse(v)).ToArray();
                int alisa = 0;
                int bob = 0;
                int turn = 1;
                int left = 0;
                int right = arr.Length - 1;
                int eatenLastTurn = 0;
                while (left <= right)
                {
                    int eaten = 0;

                    if (turn % 2 == 1)
                    {
                        //Alisa
                        while (left <= right && eaten <= eatenLastTurn)
                        {
                            eaten += arr[left];
                            left++;
                        }
                        alisa += eaten;

                    }
                    else
                    {
                        //Bob                        
                        while (right >= left && eaten <= eatenLastTurn)
                        {
                            eaten += arr[right];
                            right--;
                        }
                        bob += eaten;
                    }
                    eatenLastTurn = eaten;
                    turn++;
                }
                Console.WriteLine(string.Format("{0} {1} {2}", turn - 1, alisa, bob));
            }
        }
    }
}
