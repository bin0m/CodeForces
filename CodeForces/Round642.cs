using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForces
{
    public class Round642
    {
        // input:
        // 1 100
        public static void A_MostUnstableArray()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int i = 0; i < t; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int n = int.Parse(ss2[0]);
                int m = int.Parse(ss2[1]);
                if (n == 1)
                {
                    Console.WriteLine(0);
                    continue;
                }
                else if (n == 2)
                {
                    Console.WriteLine(m);
                    continue;
                }
                else if (n > 2)
                {
                    Console.WriteLine(m * 2);
                    continue;
                }
            }
        }    

        // 4 0
        // 2 2 4 3
        // 2 4 2 3
        public static void B_TwoArraysAndSwaps()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int j = 0; j < t; j++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int n = int.Parse(ss2[0]);
                int k = int.Parse(ss2[1]);
                s = Console.ReadLine();
                int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
                s = Console.ReadLine();
                int[] b = (from v in s.Split(' ') select int.Parse(v)).ToArray();

                Array.Sort(a);
                Array.Sort(b);

                int sum = a.Sum();

                for (int i = 0; i < k; i++)
                {
                    if (a[i] < b[n - 1 - i])
                    {
                        sum = sum - a[i] + b[n - 1 - i];
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine(sum);
            }
        }

        // 5       
        public static void C_BoardMoves()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int j = 0; j < t; j++)
            {
                s = Console.ReadLine().Trim();
                int n = int.Parse(s);
                long sum = 0;
                for (int i = n - 1; i > 0; i = i - 2)
                {
                    sum = sum + (long)i * 2 * i;
                }

                Console.WriteLine(sum);
            }
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

        // 6
        public static void D_ConstructingTheArray()
        {
            int t;
            string s = Console.ReadLine().Trim();
            t = int.Parse(s);

            for (int j = 0; j < t; j++)
            {
                s = Console.ReadLine().Trim();
                int n = int.Parse(s);
                int[] a = new int[n];

                if (n == 1)
                {
                    Console.WriteLine(1);
                    continue;
                }


                MaxHeap<Interval> heap = new MaxHeap<Interval>(new IntervalComparer());
                heap.Add(new Interval { l = 0, r = n - 1, len = n });
                int counter = 1;
                while (heap.Count > 0)
                {
                    Interval v = heap.ExtractDominating();
                    if (v.len < 1)
                        continue;
                    int ind = (v.l + v.r) / 2;
                    a[ind] = counter;
                    counter++;
                    if (v.len > 1)
                    {
                        var v1 = new Interval
                        {
                            l = v.l,
                            r = ind - 1
                        };
                        var v2 = new Interval
                        {
                            l = ind + 1,
                            r = v.r
                        };
                        v1.len = v1.r - v1.l + 1;
                        v2.len = v2.r - v2.l + 1;
                        heap.Add(v1);
                        heap.Add(v2);
                    }
                }
                Console.WriteLine(PrintList(a));
            }
        }
   

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

        #region MaxHeap<T> implementation (copied from stackoverflow.com)
        public abstract class Heap<T> : IEnumerable<T>
        {
            private const int InitialCapacity = 0;
            private const int GrowFactor = 2;
            private const int MinGrow = 1;

            private int _capacity = InitialCapacity;
            private T[] _heap = new T[InitialCapacity];
            private int _tail = 0;

            public int Count { get { return _tail; } }
            public int Capacity { get { return _capacity; } }

            protected Comparer<T> Comparer { get; private set; }
            protected abstract bool Dominates(T x, T y);

            protected Heap() : this(Comparer<T>.Default)
            {
            }

            protected Heap(Comparer<T> comparer) : this(Enumerable.Empty<T>(), comparer)
            {
            }

            protected Heap(IEnumerable<T> collection)
                : this(collection, Comparer<T>.Default)
            {
            }

            protected Heap(IEnumerable<T> collection, Comparer<T> comparer)
            {
                if (collection == null) throw new ArgumentNullException("collection");
                if (comparer == null) throw new ArgumentNullException("comparer");

                Comparer = comparer;

                foreach (var item in collection)
                {
                    if (Count == Capacity)
                        Grow();

                    _heap[_tail++] = item;
                }

                for (int i = Parent(_tail - 1); i >= 0; i--)
                    BubbleDown(i);
            }

            public void Add(T item)
            {
                if (Count == Capacity)
                    Grow();

                _heap[_tail++] = item;
                BubbleUp(_tail - 1);
            }

            private void BubbleUp(int i)
            {
                if (i == 0 || Dominates(_heap[Parent(i)], _heap[i]))
                    return; //correct domination (or root)

                Swap(i, Parent(i));
                BubbleUp(Parent(i));
            }

            public T GetMin()
            {
                if (Count == 0) throw new InvalidOperationException("Heap is empty");
                return _heap[0];
            }

            public T ExtractDominating()
            {
                if (Count == 0) throw new InvalidOperationException("Heap is empty");
                T ret = _heap[0];
                _tail--;
                Swap(_tail, 0);
                BubbleDown(0);
                return ret;
            }

            private void BubbleDown(int i)
            {
                int dominatingNode = Dominating(i);
                if (dominatingNode == i) return;
                Swap(i, dominatingNode);
                BubbleDown(dominatingNode);
            }

            private int Dominating(int i)
            {
                int dominatingNode = i;
                dominatingNode = GetDominating(YoungChild(i), dominatingNode);
                dominatingNode = GetDominating(OldChild(i), dominatingNode);

                return dominatingNode;
            }

            private int GetDominating(int newNode, int dominatingNode)
            {
                if (newNode < _tail && !Dominates(_heap[dominatingNode], _heap[newNode]))
                    return newNode;
                else
                    return dominatingNode;
            }

            private void Swap(int i, int j)
            {
                T tmp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = tmp;
            }

            private static int Parent(int i)
            {
                return (i + 1) / 2 - 1;
            }

            private static int YoungChild(int i)
            {
                return (i + 1) * 2 - 1;
            }

            private static int OldChild(int i)
            {
                return YoungChild(i) + 1;
            }

            private void Grow()
            {
                int newCapacity = _capacity * GrowFactor + MinGrow;
                var newHeap = new T[newCapacity];
                Array.Copy(_heap, newHeap, _capacity);
                _heap = newHeap;
                _capacity = newCapacity;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _heap.Take(Count).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class MaxHeap<T> : Heap<T>
        {
            public MaxHeap()
                : this(Comparer<T>.Default)
            {
            }

            public MaxHeap(Comparer<T> comparer)
                : base(comparer)
            {
            }

            public MaxHeap(IEnumerable<T> collection, Comparer<T> comparer)
                : base(collection, comparer)
            {
            }

            public MaxHeap(IEnumerable<T> collection) : base(collection)
            {
            }

            protected override bool Dominates(T x, T y)
            {
                return Comparer.Compare(x, y) >= 0;
            }
        }

        public class MinHeap<T> : Heap<T>
        {
            public MinHeap()
                : this(Comparer<T>.Default)
            {
            }

            public MinHeap(Comparer<T> comparer)
                : base(comparer)
            {
            }

            public MinHeap(IEnumerable<T> collection) : base(collection)
            {
            }

            public MinHeap(IEnumerable<T> collection, Comparer<T> comparer)
                : base(collection, comparer)
            {
            }

            protected override bool Dominates(T x, T y)
            {
                return Comparer.Compare(x, y) <= 0;
            }
        }

        #endregion

    }
}

