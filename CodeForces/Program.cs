using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeForces
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
            //input:
            // 2
            // 3 10
            // 1 5
            int n;
            string s = Console.ReadLine().Trim();
            n = int.Parse(s);

            var intersections = new Dictionary<int,int>();
            var lines = new List<Tuple<int, int>>();

            for (int i = 0; i < n; i++)
            {
                string s2 = Console.ReadLine().Trim();
                var ss2 = s2.Split(' ');
                int l = int.Parse(ss2[0]);
                int r = int.Parse(ss2[1]);
                lines.Add(new Tuple<int, int>(l, r));
                for (int j = l; j <= r ; j++)
                {
                    if(intersections.ContainsKey(j))
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

            // clear unnessacery keys
            foreach (var keyValuePair in intersections)
            {           
                if(keyValuePair.Value < n-1 )
                {

                    intersections.Remove(keyValuePair.Key);
                }     
                else
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
            }

            // find max intersection in Complete List
            var maxIntersection = 0;
            var currentIntersection = 1;
            completePoints.Sort();
            int prevX = -2;
            foreach(var x in completePoints)
            {
                if(x-1 == prevX)
                {
                    currentIntersection++;
                }
                else
                {
                    maxIntersection = Math.Max(maxIntersection, currentIntersection);
                    currentIntersection = 1;
                }
                prevX = x;
            }

            maxIntersection = Math.Max(maxIntersection, currentIntersection);

            //check all incomplete points
            foreach (var problemX in incompletePoints )
            {
                //find problem line
                Tuple<int, int> problemLine = new Tuple<int, int>(-1,1);
                foreach (var line in lines)
                {
                    if(problemX < line.Item1 || problemX > line.Item2)
                    {
                        problemLine = line;
                        break;
                    }
                }
                currentIntersection = 1;

                // go down
                int i = problemX - 1;
                while(true)
                {
                    if (intersections.ContainsKey(i))
                    {
                        if(intersections[i] == n || 
                            (intersections[i] == n - 1 && (i >= problemLine.Item1 && i <= problemLine.Item2))
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
                i = problemX + 1;
                while (true)
                {
                    if (intersections.ContainsKey(i))
                    {
                        if (intersections[i] == n ||
                            (intersections[i] == n - 1 && (i <= problemLine.Item1 && i >= problemLine.Item2))
                            )
                        {
                            currentIntersection++;
                        }
                        else
                        {
                            maxIntersection = Math.Max(maxIntersection, currentIntersection);
                            currentIntersection = 1;
                            break;

                        }
                    }
                    else
                    {
                        maxIntersection = Math.Max(maxIntersection, currentIntersection);
                        currentIntersection = 1;
                        break;
                    }
                    i++;
                }
            }


            Console.WriteLine(maxIntersection);

        }
    }
}
