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

        // input:
        // 3
        // 4 5
        // 1 2
        // 9 20
        public static void MaxIntersection()
        {
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            var intersections = new Dictionary<int, int>();
            var lines = new List<Tuple<int, int>>();

            for (int i = 0; i < n; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int l = int.Parse(ss2[0]);
                int r = int.Parse(ss2[1]);
                lines.Add(new Tuple<int, int>(l, r));
                for (int j = l; j <= r; j++)
                {
                    if (intersections.ContainsKey(j))
                    {
                        intersections[j]++;
                    }
                    else
                    {
                        intersections[j] = 1;
                    }
                }
            }

            //List of incomplete points
            var incompletePoints = new List<int>();
            var completePoints = new List<int>();

            // choose n and n-1 keys
            foreach (var keyValuePair in intersections)
            {
                if (keyValuePair.Value == n - 1)
                {
                    incompletePoints.Add(keyValuePair.Key);
                }
                if (keyValuePair.Value == n)
                {
                    completePoints.Add(keyValuePair.Key);
                }

            }

            // find max intersection in Complete List
            var maxIntersection = 0;
            var currentIntersection = 0;
            completePoints.Sort();
            int prevX = -2;
            foreach (var x in completePoints)
            {
                if (x - 1 == prevX)
                {
                    currentIntersection++;
                }
                else
                {
                    maxIntersection = Math.Max(maxIntersection, currentIntersection);
                    currentIntersection = 0;
                }
                prevX = x;
            }

            maxIntersection = Math.Max(maxIntersection, currentIntersection);

            var checkedUntil = 0;
            var checkedAfter = int.MaxValue;
            //check all incomplete points
            incompletePoints.Sort();
            foreach (var tryingX in incompletePoints)
            {
                // if this point was in previous problem line, no need to check again
                if (tryingX < checkedUntil || tryingX > checkedAfter)
                {
                    continue;
                }
                //find problem line
                Tuple<int, int> problemLine = new Tuple<int, int>(-1, 1);

                foreach (var line in lines)
                {
                    if (tryingX < line.Item1 || tryingX > line.Item2)
                    {
                        problemLine = line;
                        checkedUntil = Math.Max(checkedUntil, line.Item1);
                        checkedAfter = Math.Min(checkedAfter, line.Item2);
                        break;
                    }
                }
                currentIntersection = 0;

                // go down
                int i = tryingX - 1;
                while (i >= 0)
                {
                    if (intersections.ContainsKey(i))
                    {
                        if (intersections[i] == n ||
                            (intersections[i] == n - 1 && (i < problemLine.Item1 || i > problemLine.Item2))
                            )
                        {
                            currentIntersection++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    i--;
                }
                // go up
                i = tryingX + 1;
                while (true)
                {
                    if (intersections.ContainsKey(i))
                    {
                        if (intersections[i] == n ||
                            (intersections[i] == n - 1 && (i < problemLine.Item1 || i > problemLine.Item2))
                            )
                        {
                            currentIntersection++;
                        }
                        else
                        {
                            maxIntersection = Math.Max(maxIntersection, currentIntersection);
                            currentIntersection = 0;
                            break;

                        }
                    }
                    else
                    {
                        maxIntersection = Math.Max(maxIntersection, currentIntersection);
                        currentIntersection = 0;
                        break;
                    }
                    i++;
                }
            }
            Console.WriteLine(maxIntersection);
        }

        // input:
        // 2
        // 2 2 3
        // 4 3 7
        static void HodbaPodiagonali()
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
        }

        // helper
        private static long GetMaxDiagonalMoves(long x, long y, long k)
        {
            long ans = -1;

            if (k < Math.Max(x, y))
            {
                return ans;
            }

            if ((x + y) % 2 == 0)
            {
                if (x % 2 == 0)
                {
                    if (k % 2 == 0)
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
        }

        // input:
        // 2
        // output:
        // (())
        // ()()
        public static void GenerateBracketsPermutations()
        {
            string s = Console.ReadLine().Trim();
            int n = int.Parse(s);
            GenerateBracketsPermutationsRecursive("", n, n);

        }

        private static void GenerateBracketsPermutationsRecursive(string s, int openeres, int closers)
        {
            if (closers == 0)
            {
                Console.WriteLine(s);
                return;
            }

            if (openeres > 0)
            {
                GenerateBracketsPermutationsRecursive(s + "(", openeres - 1, closers);
            }

            if (closers > 0 && closers > openeres)
            {
                GenerateBracketsPermutationsRecursive(s + ")", openeres, closers - 1);
            }
        }

        
    }
}
