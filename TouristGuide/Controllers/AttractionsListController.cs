using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using TouristGuide.Providers.Database;
using TouristGuide.Helpers;
using System.Data.Entity;
using System.Web.Security;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TouristGuide.Controllers
{
    [Authorize]
    public class AttractionsListController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();
        private IDataProvider users = new SqlProvider();
       
        //
        // GET: /AttractionsLists/

        public ViewResult Index(int id)
        {
            var attractionsLists = db.AttractionsLists.Where(x => x.ListId == id).Select(x => x.AttractionId).ToList();
            var attractions = db.Attraction.Include(c =>c.Coordinates).Where(x => attractionsLists.Contains(x.ID)).ToList();
            ViewBag.ListID = id;
            ViewBag.ListName = db.UserLists.Where(x => x.ID == id).Select(x => x.Name).Single();
            return View(attractions);

        }
        public ActionResult Delete(int id, int listId) // trzeba coś wymyślić z list id
        {
            
            AttractionsList attractionL = db.AttractionsLists.Where(x => x.AttractionId == id && x.ListId == listId).Single();
            db.AttractionsLists.Remove(attractionL);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = listId });
        }
        public ActionResult Show(int id)
        {
            var attractionsLists = db.AttractionsLists.Where(x => x.ListId == id).Select(x=>x.AttractionId).ToList();
            var attractions = db.Attraction.Where(x => attractionsLists.Contains(x.ID)).ToList();
            ViewBag.ListID = id;
            return View("AttractionList",attractions);
        }
        public ActionResult NewAttraction(int listId)
        {
            var attractions = db.Attraction.ToList();
            ViewBag.ListID = listId;
            return View("NewAttraction", attractions);
        }

        public ActionResult AddNewAttraction()
        {
            int listId = Convert.ToInt32(Request.Form["list"]);
            AttractionsList a = new AttractionsList();



            a.AttractionId = Convert.ToInt32(Request.Form["Attractions"]);
            a.ListId = listId;

            db.AttractionsLists.Add(a);

            db.SaveChanges();
            return RedirectToAction("Index", new { id = listId }); 
        }
    }
}
