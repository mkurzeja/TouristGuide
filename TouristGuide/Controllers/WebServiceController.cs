using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Web.Security;
using TouristGuide.Providers.Database;
using TouristGuide.Helpers;
using System.IO;
using System.Drawing;

namespace TouristGuide.Controllers
{
    [WebService]
    public class WebServiceController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();
        private IDataProvider users = new SqlProvider();

        // GET: /WebService/GetAttractions?place=Name
        [WebMethod]
        public JsonResult GetAttractions(string place, int start, int count)
        {
            var attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address);

            if (place != null)
            {
                attractions = attractions.Where(p => p.Address.City == place || p.Address.Region == place);
            }

            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractionsByIds?ids=id1,id2
        [WebMethod]
        public JsonResult GetAttractionsByIds(string ids, int start, int count)
        {
            List<Attraction> attractions;
            string[] Ids = ids.Split(',');
            int[] Ids_int = new int[Ids.Count()];
            for (int i = 0; i < Ids.Length; ++i)
                Ids_int[i] = int.Parse(Ids[i]);
            attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address).
                Where(a => Ids_int.Contains(a.ID)).ToList();
            foreach (var attr in attractions)
                attr.Description = Regex.Replace(attr.Description, @"<.*?>", string.Empty);
            //return Json(attractions, JsonRequestBehavior.AllowGet);
            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractions/2
        [WebMethod]
        public JsonResult GetAttraction(int id)
        {
            var attraction = db.Attraction.Include(a => a.Address).Include(i => i.Images).Include(c => c.Coordinates).Include(r => r.Reviews)
                .Where(x => x.ID == id).SingleOrDefault();

            if (attraction == null)
                return null;

            attraction.Description = Regex.Replace(attraction.Description, @"<.*?>", string.Empty);
            attraction.Images.ForEach(x =>
            {
                var s1 = Url.Action("Index", "Home", null, "http");
                String path = s1 + "Content/AttractionImages";
                x.FileName = path + "/" + x.FileName;
            });
            //return Json(attraction, JsonRequestBehavior.AllowGet);
            return Json(new { attraction = attraction }, JsonRequestBehavior.AllowGet);
        }

         // GET: /WebService/GetAttractionsForMap/1;2
        [WebMethod]
        public JsonResult GetAttractionsForMap(String ids)
        {
            String[] ids1 = ids.Split(';');
            List<int> ids2 = new List<int>();
            ids1.ToList().ForEach(x =>
                {
                    int val = 0;
                    Int32.TryParse(x, out val);
                    ids2.Add(val);
                });

            var attractions = db.Attraction.Include(a => a.Address).Include(i => i.Images)
                .Include(c => c.Coordinates).Include(r => r.Reviews)
                .Where(x => ids2.Contains(x.ID)).Select(x => new { x.ID, x.Name, x.Coordinates.Latitude, x.Coordinates.Longitude }).ToList();
            if (attractions == null)
                return null;

            return Json(new { attractions = attractions }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractions?name=Name
        [WebMethod]
        public JsonResult GetAttractionByName(string name)
        {
            var attraction = db.Attraction.Include(c => c.Country).Include(a => a.Address).
                FirstOrDefault(x => x.Name.Contains(name));

            if (attraction != null)
            {
                attraction.Description = Regex.Replace(attraction.Description, @"<.*?>", string.Empty);
                return Json(new { attraction = attraction }, JsonRequestBehavior.AllowGet);
            }

            return Json("empty", JsonRequestBehavior.AllowGet);
        }
        // GET: /WebService/GetAttractions?name=Name
        [WebMethod]
        public JsonResult GetAttractionsByName(string name)
        {
            var attractions = db.Attraction.Select(x => new { x.ID, x.Name }).Where(x => x.Name.Contains(name));

            if (attractions != null)
            {
                return Json(new { attractions = attractions }, JsonRequestBehavior.AllowGet);
            }

            return Json("empty", JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractionsByType
        [WebMethod]
        public JsonResult GetAttractionsByType(string type, int start, int count)
        {
            List<Attraction> attractions;
            if (type != null)
            {
                attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address).
                    Where(p => p.AttractionType.Name == type).ToList();
            }
            else
                attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address).ToList();
            foreach (var attr in attractions)
                attr.Description = Regex.Replace(attr.Description, @"<.*?>", string.Empty);
            //return Json(attractions, JsonRequestBehavior.AllowGet);
            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractionsByPlace
        [WebMethod]
        public JsonResult GetAttractionsByPlace(string name, int start, int count)
        {
            var attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address);
            if (name != null)
            {
                attractions = attractions.Where(p => p.Address.City == name || p.Address.Region == name);
            }
            //return Json(attractions, JsonRequestBehavior.AllowGet);
            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractionsByCountry
        [WebMethod]
        public JsonResult GetAttractionsByCountry(string country, int start, int count)
        {
            var attractions = db.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address);
            if (country != null)
            {
                attractions = attractions.Where(p => p.Country.Name == country);
            }
            //return Json(attractions, JsonRequestBehavior.AllowGet);
            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetAttractionsByPlaceId/3
        [WebMethod]
        public JsonResult GetAttractionsByPlaceId(int start, int count, int id = -1)
        {
            var attractions = db.Attraction.Include(x => x.Address);
            if (id != -1)
            {
                var place = db.Place.Find(id);
                attractions = attractions.Where(p => p.Address.City == place.Name || p.Address.Region == place.Name);
            }
            //return Json(attractions, JsonRequestBehavior.AllowGet);
            var attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            });

            return Json(new { attractions = attrs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetPlace/3
        [WebMethod]
        public JsonResult GetPlace(int id)
        {
            var place = db.Place.Find(id);
            place.Description = Regex.Replace(place.Description, @"<.*?>", string.Empty);
            //return Json(place, JsonRequestBehavior.AllowGet);
            return Json(new { place = place }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetPlaces?country=Name
        [WebMethod]
        public JsonResult GetPlaces(string country, int start, int count)
        {
            var places = db.Place.Include(x => x.Country);
            if (country != null)
                places = places.Where(p => p.Country.Name == country);
            //return Json(places, JsonRequestBehavior.AllowGet);
            var placs = places.OrderBy(x => x.Name).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            });
            return Json(new { places = placs.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetCountry/3
        [WebMethod]
        public JsonResult GetCountry(int id)
        {
            var country = db.Country.Find(id);
            if(country!=null)
            {
                country.Description = Regex.Replace(country.Description, @"<.*?>", string.Empty);
                return Json(new { country = country }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { country = "Cannot find description!" }, JsonRequestBehavior.AllowGet);
            }         

        }

        // GET: /WebService/GetCountries
        [WebMethod]
        public JsonResult GetCountries(int start, int count)
        {
            var countries = db.Country.OrderBy(x => x.Name).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            });
            //return Json(countries, JsonRequestBehavior.AllowGet);
            return Json(new { countries = countries.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetCountries
        [WebMethod]
        public JsonResult GetPlacesList(int start, int count)
        {
            var places = db.Place.OrderBy(x => x.Name).Skip(start).Take(count).Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            });
            //return Json(countries, JsonRequestBehavior.AllowGet);
            return Json(new { places = places.ToList() }, JsonRequestBehavior.AllowGet);
        }
       

        // GET: /WebService/GetAttractionsByLatLng
        [WebMethod]
        public JsonResult GetAttractionsByLatLng(double lat, double lng)
        {
            var attractions = db.Attraction.Include(c => c.Coordinates)
                .Where(x => x.Coordinates.Latitude > lat - 1 && x.Coordinates.Latitude < lat + 1 && x.Coordinates.Longitude > lng - 1 && x.Coordinates.Longitude < lng + 1)
                .OrderBy(x => x.AvgRating).Take(100).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Coordinates = x.Coordinates
            });
            //return Json(countries, JsonRequestBehavior.AllowGet);
            return Json(new { attractions = attractions.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult RegisterUser(string username, string pass, string email)
        {
            MembershipCreateStatus createStatus;
            Membership.CreateUser(username, pass, email, null, null, true, null, out createStatus);
            System.Web.Security.Roles.AddUserToRole(username, "user");
            if (createStatus == MembershipCreateStatus.Success)
            {
                var tokken = GenerateToken(username);
                return Json(tokken, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        private String GenerateToken(string user)
        {
            String tokken = "";

            var id = users.GetUserByLogin(user).UserId;
            tokken = HashHelper.CalculateMD5Hash(id.ToString() + DateTime.Now.Ticks.ToString());
            var el = new UserTokken() { Tokken = tokken, UserId = id, LastAccessTime = DateTime.Now };

            var del = db.UserTokkens.SingleOrDefault(x => x.UserId == id);
            if (del != null)
                db.UserTokkens.Remove(del);

            db.UserTokkens.Add(el);
            db.SaveChanges();

            return tokken;
        }

        // GET: /WebService/MobileLogOn
        [WebMethod]
        public JsonResult MobileLogOn(string user, string pass)
        {
            String tokken = "";

            if (Membership.ValidateUser(user, pass))
            {
                tokken = GenerateToken(user);
            }
            else
            {
                tokken = "error";
            }

            return Json(tokken, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/GetFavourites
        [WebMethod]
        [CheckTokkenFilter]
        public JsonResult GetFavourites(string tokken, int userId = 0)
        {
            var myAttractions = db.MyAttractions.Where(x => x.UserId == userId).Select(x => x.AttractionId).ToList();
            var attractions = db.Attraction.Where(x => myAttractions.Contains(x.ID));
            return Json(new { attractions = attractions.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/UserAttractionLists
        [WebMethod]
        [CheckTokkenFilter]
        public JsonResult GetUserAttractionLists(string tokken, int userId = 0)
        {
            var userlists = db.UserLists.Where(x => x.UserId == userId).ToList();
            return Json(new { attractionLists = userlists }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/AttractionsByUserList
        [WebMethod]
        [CheckTokkenFilter]
        public JsonResult GetAttractionsByUserList(string tokken, int listId, int userId = 0)
        {
            var list = db.UserLists.SingleOrDefault(x => x.UserId == userId && x.ID == listId);

            if (list == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            var attractionsIds = db.AttractionsLists.Where(x => x.ListId == listId).Select(x => x.AttractionId).ToList();
            var attractions = db.Attraction.Include(c => c.Country).Include(a => a.Address).
                Where(x => attractionsIds.Contains(x.ID)).ToList();
            attractions.ForEach(x => x.Description = Regex.Replace(x.Description, @"<.*?>", string.Empty));
            return Json(new { attractions = attractions }, JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/AddPhotoToAttraction
        [WebMethod]
        [HttpPost]
        [CheckTokkenFilter]
        public JsonResult AddPhotoToAttraction(string tokken, int attrId, int userId = 0)
        {
            //check user role for permission??

            byte[] image = new byte[Request.InputStream.Length];
            Request.InputStream.Read(image, 0, image.Length);

            if (Request.InputStream.Length == 0)
                return Json("false", JsonRequestBehavior.AllowGet);

            MemoryStream ms = new MemoryStream(image);
            Bitmap bitmap = new Bitmap(ms);
            var name = HashHelper.CalculateMD5Hash(new Guid().ToString());
            String path = HttpContext.Server.MapPath("~/Content/AttractionImages");
            bitmap.Save(path + "/" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            var ati = new AttractionImage() { AttractionID = attrId, FileName = name + ".jpg" };
            db.AttractionImage.Add(ati);
            db.SaveChanges();

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        // GET: /WebService/AttractionsByUserList
        //[WebMethod]
        //public JsonResult GetPhoto()
        //{
        //    String path = HttpContext.Server.MapPath("~/Content/images");
        //    Bitmap bt = new Bitmap(path + "/404.jpg");
        //    MemoryStream ms = new MemoryStream();
        //    bt.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return Json(new { photo = ms.ToArray() }, JsonRequestBehavior.AllowGet);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}