using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Web.Security;
using TouristGuide.Helpers;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace TouristGuide.Controllers

{
    public class ShortestPathController : Controller
    {
        //
        // GET: /ShortestPath/
        private TouristGuideDB db = new TouristGuideDB();
  

        public string getPoints(int id)
        {
            var attractionsLists = db.AttractionsLists.Where(x => x.ListId == id).Select(x => x.AttractionId).ToList();
            var attractions = db.Attraction.Include(c=>c.Coordinates).Where(x => attractionsLists.Contains(x.ID)).ToList();

            
            Attraction[] atTab = new Attraction[attractions.Count];
            if (attractions.Count == 0)
                return "";
            atTab = attractions.ToArray();
            double[,] distances = new double[atTab.Length, atTab.Length];

            for (int i = 0; i < atTab.Length; i++)
                for (int j = 0; j < atTab.Length; j++)
                {
                    double cosq = Math.Sin(atTab[i].Coordinates.Latitude) * Math.Sin(atTab[j].Coordinates.Latitude) +
                        Math.Cos(atTab[i].Coordinates.Latitude) * Math.Cos(atTab[j].Coordinates.Latitude) * Math.Cos(atTab[i].Coordinates.Longitude - atTab[j].Coordinates.Longitude);
                    double R = 6400;
                    double d = (2 * Math.PI * R * Math.Acos(cosq)) / 360;
                    distances[i, j] = d;
                }
            List<int> all = new List<int>();
            for (int i=0; i<atTab.Length; i++)
                all.Add(i);
            Greedy g = new Greedy(distances, all);
            List<int> tmp = g.CountDistance(0);

            string s = "http://dev.virtualearth.net/REST/v1/Routes?";
        //wp.0=london&wp.1=leeds&avoid=minimizeTolls&key=
            int l=0;
            foreach (int i in tmp)
            {
                s+=l==0?"wp.":"&wp.";
                s+=l+"="+atTab[i].Coordinates.Latitude+","+atTab[i].Coordinates.Longitude;
                l++;
            }
            s += "&routePathOutput=Points&output=json&jsonp=RouteCallback&key=";
            return s;
        }

    }
}
