using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class UnApprovedReviewController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        //
        // GET: /ApprovedReview/

        public ActionResult Index()
        {
            var reviews = db.AttractionReview.Where(x => x.isApproved == 0).ToList();
            if (reviews.Count == 0)
                reviews = null;
            return View(reviews);
        }

        public ActionResult Approve(int id)
        {
            //var reviews = db.AttractionReview.Where(x => x.isApproved == 0).ToList();

            AttractionReview approved = db.AttractionReview.Where(x => x.ID == id).Single();
            approved.isApproved = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
