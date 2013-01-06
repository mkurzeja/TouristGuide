using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class ModerationController : Controller
    {
        //
        // GET: /UnApprovedImage/
        private TouristGuideDB db = new TouristGuideDB();

        public ActionResult ImageIndex()
        {
            var images = db.AttractionImage.Where(x => x.isApproved == 0).ToList();
            if (images.Count == 0)
                images = null;
            return View(images);
        }

        public ActionResult ImageApprove(int id)
        {
            AttractionImage approved = db.AttractionImage.Where(x => x.ID == id).Single();
            approved.isApproved = 1;
            db.SaveChanges();
            return RedirectToAction("ImageIndex");
        }

        // GET: /ApprovedReview/

        public ActionResult ReviewIndex()
        {
            var reviews = db.AttractionReview.Where(x => x.isApproved == 0).ToList();
            if (reviews.Count == 0)
                reviews = null;
            return View(reviews);
        }

        public ActionResult ReviewApprove(int id)
        {
            //var reviews = db.AttractionReview.Where(x => x.isApproved == 0).ToList();

            AttractionReview approved = db.AttractionReview.Where(x => x.ID == id).Single();
            approved.isApproved = 1;
            db.SaveChanges();
            return RedirectToAction("ReviewIndex");
        }
    }
}
