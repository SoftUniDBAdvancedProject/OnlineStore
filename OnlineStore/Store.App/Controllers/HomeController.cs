using System.Web.Mvc;

namespace Store.App.Controllers
{
    using System.Linq;
    using Data;

    public class HomeController : BaseController
    {
        public HomeController(StoreContext data) : base(data)
        {
        }

        public ActionResult Index()
        {
            //test base controller
            this.ViewData["users"] = this.Data.Users.ToList();
            this.ViewData["currentUser"] = this.UserProfile;

            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}