using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    class Helpers
    {
        // 4 1 0 4 
        static int[] LineToArray(string line)
        {
            return (from v in line.Split(' ') select int.Parse(v)).ToArray();
        }


        static string PrintList(IList<int> list)
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
