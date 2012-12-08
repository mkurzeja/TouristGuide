using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristGuide.Helpers
{
    class Greedy
    {
        double[,] distances;
        List<int> solution = new List<int>();
        List<int> all;
        public Greedy(double[,] distances, List<int> at)
        {
            this.distances = distances;
            this.all= at;
        }


        public List<int> CountDistance(int start)
        {
            solution.Add(start);
            all.Remove(start);
            double minimum = double.MaxValue;
            int i = 0;
            int index = 0;
            double distance = 0;
            foreach (int p in all)
            {
                distance = distances[p, start]; 
                if (distance < minimum)
                {
                    minimum = distance;
                    index = i;
                }
                i++;
            }
            if (all.Count != 0)
            {
                CountDistance(all[index]);
            }
            return solution;
        }
    }
}