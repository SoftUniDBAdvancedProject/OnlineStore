using System.Web.Mvc;

namespace Store.App.Controllers
{
    using System.Linq;
    using Data;
    using Services;

    public class HomeController : BaseController
    {
        public HomeController(Context data) : base(data)
        {
        }

        public ActionResult Index()
        {
            //test base controller
            var manager = new ProductService();
            var products = manager.Get().OrderByDescending(c => c.Id).Take(3).ToList();
            return this.View(products);
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