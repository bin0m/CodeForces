using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class MediumProblems
    {
        // input:
        // 8 3
        // 5 4 2 6 5 1 9 2
        void PolikarpTraining()
        {
            int n;
            int k;
            string s = Console.ReadLine().Trim();
            var ss = s.Split(' ');
            n = int.Parse(ss[0]);
            k = int.Parse(ss[1]);

            s = Console.ReadLine();
            int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
            if (k == 1)
            {
                Console.WriteLine(a.Max());
                Console.WriteLine(n);
                return;
            }


            int[] sorted = new int[n];

            a.CopyTo(sorted, 0);
            Array.Sort(sorted);

            var maximums = new List<int>(k);
            //maximums.AddRange(sorted.TakeLast(k));
            for (int i = n - 1; i >= n - k; i--)
            {
                maximums.Add(sorted[i]);
            }
            int bestEfficiency = maximums.Sum();
            StringBuilder sb = new StringBuilder();
            int lastIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (maximums.Contains(a[i]))
                {
                    sb.Append(i - lastIndex);
                    sb.Append(' ');
                    lastIndex = i;
                    maximums.Remove(a[i]);
                }
                if (maximums.Count == 1)
                {
                    sb.Append(n - 1 - lastIndex);
                    break;
                }
            }
            Console.WriteLine(bestEfficiency);
            Console.WriteLine(sb.ToString());
        }

        // input:
        // 5
        // 1 3 1 1 4
        void ThreePartsOfArray()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            s = Console.ReadLine();
            long[] a = (from v in s.Split(' ') select long.Parse(v)).ToArray();
            long maxEqualSum = 0;

            if (n > 1)
            {
                int leftIndex = 0;
                int rightIndex = n - 1;

                long sumOfLeftPart = a[leftIndex];
                long sumOfRightPart = a[rightIndex];

                while (leftIndex < rightIndex)
                {
                    if (sumOfLeftPart == sumOfRightPart)
                    {
                        maxEqualSum = sumOfLeftPart;
                        leftIndex++;
                        rightIndex--;
                        sumOfLeftPart += a[leftIndex];
                        sumOfRightPart += a[rightIndex];
                    }
                    else
                    {
                        if (sumOfLeftPart > sumOfRightPart)
                        {
                            rightIndex--;
                            sumOfRightPart += a[rightIndex];
                        }
                        else
                        {
                            leftIndex++;
                            sumOfLeftPart += a[leftIndex];
                        }
                    }
                }
            }

            Console.WriteLine(maxEqualSum);
        }

        //input: 
        //10 2 15
        void MezhduDomami()
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
