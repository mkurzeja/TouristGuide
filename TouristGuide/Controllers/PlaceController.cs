using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using TouristGuide.Helpers;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace TouristGuide.Controllers
{ 
    public class PlaceController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        //
        // GET: /Place/

        public ViewResult Index(string country, int start = 0, int count = 20)
        {
            List<Place> places = FilterPlaces(country, null, start, count);
            return View(places);
        }

        private List<Place> FilterPlaces(string country, string place, int start, int count)
        {
            IQueryable<Place> places = db.Place.Include(c => c.Country).Include(c => c.Coordinates);

            if (country != null && country != "")
            {
                places = places.Where(a => a.Country != null && a.Country.Name.Contains(country));
            }
            if (place != null && place != "")
            {
                places = places.Where(a => a.Name.Contains(place));
            }

            return places.OrderBy(x => x.Name).Skip(start).Take(count).ToList();
        }

        public ViewResult GetPlaces(string country, string place, int start, int count)
        {
            List<Place> places = FilterPlaces(country, place, start, count);
            return View(places);
        }

        //
        // GET: /Place/Details/5

        public ViewResult Details(int id)
        {
            Place place = db.Place.Include(c => c.Country).Include(c => c.Coordinates).Where(p => p.ID == id).SingleOrDefault();
            return View(place);
        }

        //
        // GET: /Place/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.Countries = DbHelpers.GetCountriesToList();
            return View();
        } 

        //
        // POST: /Place/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Place place)
        {
            place.Country = db.Country.Find(place.Country.ID);
            db.Place.Add(place);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        
        //
        // GET: /Place/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = DbHelpers.GetCountriesToList();
            Place place = db.Place.Include(c => c.Country).Include(c => c.Coordinates).Where(p => p.ID == id).SingleOrDefault();
            return View(place);
        }

        //
        // POST: /Place/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Place place)//, int CountryId)
        {
            //place.Country = db.Country.Find(CountryId);
            ////place.Country.ID = CountryId;
            //if (ModelState.IsValid)
            //{
            //    UpdateModel(place);
            //    //db.Entry(place).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Countries = DbHelpers.GetCountriesToList();
            //return View(place);
            var updatedPlace = db.Place.Include(c => c.Country).Include(c => c.Coordinates).Where(p => p.ID == place.ID).SingleOrDefault();
            updatedPlace.Coordinates.Latitude = place.Coordinates.Latitude;
            updatedPlace.Coordinates.Longitude = place.Coordinates.Longitude;
            updatedPlace.Country = db.Country.Find(place.Country.ID);
            updatedPlace.Description = place.Description;
            updatedPlace.Name = place.Name;
            db.Entry(updatedPlace).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Place/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Place place = db.Place.Find(id);
            return View(place);
        }

        //
        // POST: /Place/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Place place = db.Place.Find(id);
            db.Place.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AttractionsForPlace(string place)
        {
            //Get the data from the database
            var attractions = db.Attraction.Where(x => x.Address.City == place || x.Address.Region == place).Include(c => c.Coordinates).Take(100);
            List<PushPinModel> pushpins = new List<PushPinModel>();

            //add info to list of pushpins
            foreach (var attraction in attractions)
            {
                //set the html to pass into the description
                string descriptionHtml;
                if (attraction.Description.Length > 200)
                {
                    descriptionHtml = Regex.Replace(attraction.Description, @"<.*?>", string.Empty);
                    descriptionHtml = descriptionHtml.Substring(0, 200) + "...";
                }
                else
                    descriptionHtml = attraction.Description;

                //add the pushpin info
                pushpins.Add(new PushPinModel
                {
                    Description = descriptionHtml,
                    Latitude = attraction.Coordinates.Latitude,
                    Longitude = attraction.Coordinates.Longitude,
                    Title = "<a href=\"/Attraction/Details/" + attraction.ID + "\">" + attraction.Name + "</a>"
                });
            }

            //return the list as JSON
            return Json(pushpins);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize]
        public ActionResult removeImage(int PlaceID)
        {


            string path = AppDomain.CurrentDomain.BaseDirectory;

            Place us = db.Place.Where(x => x.ID == PlaceID).Include("Coordinates").Include("Country").Single();
            System.IO.File.Delete(Path.Combine(path, us.imgUrl));

            us.imgUrl = "";
            db.Entry(us).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = us.ID });
        }
        [Authorize]
        [HttpPost]
        public ActionResult ImageCreate(int PlaceID)
        {
            Place us = db.Place.Where(x => x.ID == PlaceID).Include("Coordinates").Include("Country").Single();
            if (us.imgUrl != null && us.imgUrl != "")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                System.IO.File.Delete(Path.Combine(path, us.imgUrl));
            }
            string FileName = "";
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Content/PlacesImages/";
                string ext = Request.Files[0].FileName.Substring(Request.Files[0].FileName.LastIndexOf('.'));
                FileName = generateRandomString(32) + ext;
                System.Diagnostics.Debug.WriteLine(FileName);
                Request.Files[0].SaveAs(Path.Combine(path, FileName));
                FileName = Path.Combine("Content/PlacesImages/", FileName);


            }
            catch (NullReferenceException)
            {
                //no photo
            }

            us.imgUrl = FileName;
            db.Entry(us).State = System.Data.EntityState.Modified;
            db.SaveChanges();
  
            return RedirectToAction("Edit", new { id = us.ID });
        }

        public String generateRandomString(int length)
        {
            //Initiate objects & vars    
            Random random = new Random();
            String randomString = "";
            int randNumber;

            //Loop ‘length’ times to generate a random number or character
            for (int i = 0; i < length; i++)
            {
                if (random.Next(1, 3) == 1)
                    randNumber = random.Next(97, 123); //char {a-z}
                else
                    randNumber = random.Next(48, 58); //int {0-9}

                //append random char or digit to random string
                randomString = randomString + (char)randNumber;
            }
            //return the random string
            return randomString;
        }
    }
}