namespace Store.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data;
    using Store.Models;

    public class BaseController : Controller
    {
        protected BaseController(Context data)
        {
            this.Data = data;
        }

        protected BaseController(Context data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected Context Data { get; private set; }

        protected User UserProfile { get; private set; }

       
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}