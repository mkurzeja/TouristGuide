using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TouristGuide.Controllers
{ 
    public class CountryController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        //
        // GET: /Country/

        public ViewResult Index(int start = 0, int count = 20)
        {
            List<Country> countries = FilterCountries(null, start, count);
            return View(countries);
        }

        private List<Country> FilterCountries(string country, int start, int count)
        {
            IQueryable<Country> countries = db.Country;

            if (country != null && country != "")
            {
                countries = countries.Where(a => a.Name.Contains(country));
            }
            
            return countries.OrderBy(x => x.Name).Skip(start).Take(count).ToList();
        }

        public ViewResult GetCountries(string country, int start, int count)
        {
            List<Country> countries = FilterCountries(country, start, count);
            return View(countries);
        }

        //
        // GET: /Country/Details/5

        public ViewResult Details(int id)
        {
            Country country = db.Country.Include(c => c.Coordinates).Where(x => x.ID == id).Single();
            return View(country);
        }

        //
        // GET: /Country/Create
        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Country/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Country.Add(country);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = country.ID });
            }

            return View(country);
        }
        
        //
        // GET: /Country/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Country country = db.Country.Find(id);
            return View(country);
        }

        //
        // POST: /Country/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = country.ID });
            }
            return View(country);
        }

        //
        // GET: /Country/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Country country = db.Country.Find(id);
            return View(country);
        }

        //
        // POST: /Country/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AttractionsForCountry(string country)
        {
            //Get the data from the database
            var places = db.Place.Where(x => x.Country.Name == country).Include(c => c.Coordinates).Take(100);
            List<PushPinModel> pushpins = new List<PushPinModel>();

            //add info to list of pushpins
            foreach (var place in places)
            {
                //set the html to pass into the description
                string descriptionHtml;
                if (place.Description.Length > 200)
                {
                    descriptionHtml = Regex.Replace(place.Description, @"<.*?>", string.Empty);
                    descriptionHtml = descriptionHtml.Substring(0, 200) + "...";
                }
                else
                    descriptionHtml = place.Description;

                //add the pushpin info
                pushpins.Add(new PushPinModel
                {
                    Description = descriptionHtml,
                    Latitude = place.Coordinates.Latitude,
                    Longitude = place.Coordinates.Longitude,
                    Title = "<a href=\"/Place/Details/" + place.ID + "\">" + place.Name + "</a>"
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
        public ActionResult removeImage(int CountryID)
        {

            
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Country us = db.Country.Where(x => x.ID == CountryID).Single();
            System.IO.File.Delete(Path.Combine(path, us.imgUrl));
            
            us.imgUrl = "";
            db.Entry(us).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = us.ID });
        }
        [Authorize]
        [HttpPost]
        public ActionResult ImageCreate(int CountryID)
        {
            Country us = db.Country.Where(x => x.ID == CountryID).Single();
            if (us.imgUrl != null && us.imgUrl != "")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                System.IO.File.Delete(Path.Combine(path, us.imgUrl));
            }
            string FileName="";
            try
            {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Content/CountriesImages/";
                    string ext = Request.Files[0].FileName.Substring(Request.Files[0].FileName.LastIndexOf('.'));
                    FileName = generateRandomString(32) + ext;
                    System.Diagnostics.Debug.WriteLine(FileName);
                    Request.Files[0].SaveAs(Path.Combine(path, FileName));
                    FileName = Path.Combine("Content/CountriesImages/", FileName);
                    
                
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