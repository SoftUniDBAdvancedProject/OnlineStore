namespace Store.App.Areas.Admin
{
    using System.Web.Mvc;

    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
           "AdminArea_default",
           "AdminArea/{controller}/{action}/{id}",
           new { controller = "Home", action = "Index", id = UrlParameter.Optional },
           new[] { "Store.App.Areas.Admin.Controllers" }
       );
        }
    }
}