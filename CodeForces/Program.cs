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
    }
}
