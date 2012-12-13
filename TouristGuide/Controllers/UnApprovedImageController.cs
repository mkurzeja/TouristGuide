using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class UnApprovedImageController : Controller
    {
        //
        // GET: /UnApprovedImage/
        private TouristGuideDB db = new TouristGuideDB();

        public ActionResult Index()
        {
            var images = db.AttractionImage.Where(x => x.isApproved == 0).ToList();
            if (images.Count == 0)
                images = null;
            return View(images);
        }

        public ActionResult Approve(int id)
        {
            AttractionImage approved = db.AttractionImage.Where(x => x.ID == id).Single();
            approved.isApproved = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
