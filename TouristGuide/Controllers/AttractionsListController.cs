using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using TouristGuide.Providers.Database;

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
            var attractions = db.Attraction.Where(x => attractionsLists.Contains(x.ID)).ToList();
            Session["ListId"] = id;
            ViewBag.ListName = db.UserLists.Where(x => x.ID == id).Select(x => x.Name).Single();
            return View(attractions);

        }
        public ActionResult Delete(int id) // trzeba coś wymyślić z list id
        {
            int listId = -1;
            if (Session["ListId"] != null) listId = (int) Session["ListId"];
            else
                return RedirectToAction("Index", "UserLists");
            AttractionsList attractionL = db.AttractionsLists.Where(x => x.AttractionId == id && x.ListId == listId).Single();
            db.AttractionsLists.Remove(attractionL);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = listId });
        }
        public ActionResult Show(int id)
        {
            var attractionsLists = db.AttractionsLists.Where(x => x.ListId == id).Select(x=>x.AttractionId).ToList();
            var attractions = db.Attraction.Where(x => attractionsLists.Contains(x.ID)).ToList();
            return View("AttractionList",attractions);
        }
        public ActionResult NewAttraction()
        {
            var attractions = db.Attraction.ToList();
           
            return View("NewAttraction", attractions);
        }

        public ActionResult AddNewAttraction()
        {
            int listId = -1;
            if (Session["ListId"] != null) listId = (int)Session["ListId"];
            else
                return RedirectToAction("Index", "UserLists");

            AttractionsList a = new AttractionsList();



            a.AttractionId = Convert.ToInt32(Request.Form["Attractions"]);
            a.ListId = listId;

            db.AttractionsLists.Add(a);

            db.SaveChanges();
            return RedirectToAction("Index", new { id = listId }); 
        }
    }
}
