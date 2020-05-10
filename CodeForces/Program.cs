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

        static string PrintList(List<int> list)
        {
            var sb = new StringBuilder();
            foreach (int a in list)
            {
                sb.Append(a);
                sb.Append(" ");
            }
            return sb.ToString();
        }

    }
}
