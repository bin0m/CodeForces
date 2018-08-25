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
            var currentIntersection = 0;
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
                    currentIntersection = 0;
                }
                prevX = x;
            }

            maxIntersection = Math.Max(maxIntersection, currentIntersection);

            var checkedUntil = 0;
            var checkedAfter = n;
            //check all incomplete points
            incompletePoints.Sort();
            foreach (var tryingX in incompletePoints )
            {
                // if this point was in previous problem line, no need to check again
                if (tryingX < checkedUntil || tryingX > checkedAfter)
                {
                    continue;
                }
                //find problem line
                Tuple<int, int> problemLine = new Tuple<int, int>(-1,1);
                
                foreach (var line in lines)
                {
                    if(tryingX > checkedUntil && ( tryingX < line.Item1 || tryingX > line.Item2 ))
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
                while( i >= 0 )
                {
                    if (intersections.ContainsKey(i))
                    {
                        if(intersections[i] == n || 
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
                while ( true )
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
    }
}
