using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Helpers
{
    public class CheckTokkenFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private TouristGuideDB db = new TouristGuideDB();
        private int sessionTime = 15;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey("tokken"))
            {
                var tokken = filterContext.ActionParameters["tokken"] as String;
                var res = db.UserTokkens.SingleOrDefault(x => x.Tokken.Equals(tokken));

                if (res != null && DateTime.Now <= res.LastAccessTime.AddMinutes(sessionTime))
                {
                    if (filterContext.ActionParameters.ContainsKey("userId"))
                        filterContext.ActionParameters["userId"] = res.UserId;

                    res.LastAccessTime = DateTime.Now;
                    db.SaveChanges();                       
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }

            filterContext.Result = new EmptyResult();            
        }
    }
}