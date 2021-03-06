﻿using System;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class EasyProblems
    {
        // input:
        // 5
        // 1 2 4 5 10
        void SosednieZameny()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            s = Console.ReadLine();
            int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    sb.Append(a[i] - 1);
                }
                else
                {
                    sb.Append(a[i]);
                }
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }

        // input:
        // 3 5
        // 2 2
        // 1 2
        // 5 5
        void TochkiVotrezkah()
        {
            int n;
            int m;
            string s = Console.ReadLine().Trim();
            var ss = s.Split(' ');
            n = int.Parse(ss[0]);
            m = int.Parse(ss[1]);
            
            bool[] points = new bool[m];

            for (int i = 0; i < n; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int l = int.Parse(ss2[0]);
                int r = int.Parse(ss2[1]);
                for (int j = l - 1; j <= r - 1; j++)
                {
                    points[j] = true;
                }
            }

            var sb = new StringBuilder();
            int counter = 0;
            for (int i = 0; i < m; i++)
            {
                if (!points[i])
                {
                    sb.Append(i + 1).Append(' ');
                    counter++;
                }
            }
            
            Console.WriteLine(counter);
            Console.WriteLine(sb.ToString());
        }

        // input:
        // 6
        // abcdef
        // abdfec
        void PoluchenieStroki()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            string t = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                //find arr[i] in t
                int j = i;
                for (; j < n; j++)
                {
                    if (arr[j] == t[i])
                    {
                        break;
                    }
                }
                //not found
                if (j == n)
                {
                    Console.WriteLine("-1");
                    return;
                }
                while (j > i)
                {
                    var temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                    sb.Append(j).Append(' ');
                    counter++;
                    j--;
                }
            }
            Console.WriteLine(counter);
            Console.WriteLine(sb.ToString());
        }
        
        // input:
        // 3 21
        // 10 8
        // 7 4
        // 3 1
        void ArchiveSongs()
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

        // input:
        // 3 2
        // cat
        static void MnogoOdinakovyhPodstrok()
        {
            int n;
            int k;
            string s = Console.ReadLine().Trim();
            var ss = s.Split(' ');
            n = int.Parse(ss[0]);
            k = int.Parse(ss[1]);

            s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            int maxLength = 0;
            int substringLength = 1;
            while (substringLength < n)
            {
                bool isSame = true;
                for (int i = 0; i < substringLength; i++)
                {
                    if (s[i] != s[n - substringLength + i])
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                {
                    maxLength = substringLength;
                }
                substringLength++;
            }

            string secondHalf = s.Substring(maxLength, n - maxLength);

            var sb = new StringBuilder(s);

            for (int i = 1; i < k; i++)
            {
                sb.Append(secondHalf);
            }

            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }

        // input:
        // 6
        // 4 7 12 100 150 199
        static void SostavlenieKontenta()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            s = Console.ReadLine();
            int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            int maxSubSetLength = 1;
            int currentSubSetLength = 1;
            for (int i = 1; i < n; i++)
            {
                if (a[i] <= a[i - 1] * 2)
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

        // input:
        // 4 3
        static void vysotaFunctsii()
        {
            ulong n;
            ulong k;
            string str = Console.ReadLine().Trim();
            var ss = str.Split(' ');
            n = ulong.Parse(ss[0]);
            k = ulong.Parse(ss[1]);
            ulong coeff = k / n;
            if (k % n != 0)
            {
                coeff++;
            }

            Console.WriteLine(coeff);
        }
    }
}
