using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using TouristGuide.Providers.Database;
using System.Data.Entity.Validation;
namespace TouristGuide.Controllers
{
    [Authorize]
    public class UserListsController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();
        private IDataProvider users = new SqlProvider();
        //
        // GET: /AttractionsLists/

        public ViewResult Index()
        {
            var id = users.GetUserByLogin(HttpContext.User.Identity.Name).UserId;
            var userList = db.UserLists.Where(x => x.UserId == id).Select(x => x).ToList();
            //var attractionsLists = db.AttractionsLists.Where(x => userList.Contains(x.ListId)).ToList();

            return View(userList);
        }
        public ActionResult Delete(int id)
        {
            UserList userList = db.UserLists.Where(x => x.ID == id).Single();

            var attractions = db.AttractionsLists.Where(x => x.ListId == userList.ID).ToList();

            foreach (AttractionsList item in attractions)
            {
                db.AttractionsLists.Remove(item);
            }

            db.UserLists.Remove(userList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Show(int idd)
        {
            return RedirectToAction("Index", "AttractionsList", new { id = idd });
        }
        public ActionResult Create()
        {
            return View("Create");
        }
        public ActionResult AddList(UserList u)
        {
            var id = users.GetUserByLogin(HttpContext.User.Identity.Name).UserId;
            u.UserId = id;
            db.UserLists.Add(u);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            
            }
            return RedirectToAction("Index");
        }
    }
}
