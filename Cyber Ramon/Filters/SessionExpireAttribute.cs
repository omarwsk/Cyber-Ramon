using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cyber_Ramon.Filters
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}