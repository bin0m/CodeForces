using System;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class EasyProblems
    {
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
    }
}
