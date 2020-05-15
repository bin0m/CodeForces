using System.Collections.Generic;

namespace CodeForces.DataStructures
{
    public class Interval
    {
        public int l;
        public int r;
        public int len;
    }

    public class IntervalComparer : Comparer<Interval>
    {
        public override int Compare(Interval x, Interval y)
        {
            if (x.len > y.len)
            {
                return 1;
            }
            if (x.len < y.len)
            {
                return -1;
            }

            if (x.l < y.l)
            {
                return 1;
            }

            if (x.l > y.l)
            {
                return -1;
            }

            return 0;
        }
    }
}
