namespace Store.App.Controllers
{
    using Services;
    using ViewModels;
    using System.Web.Mvc;

    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var managerProducts = new ProductService();
            var managerCategories = new CategoryService();

            var products = managerProducts.Get();
            var categories = managerCategories.Get();
            var model = new ShopViewModel
            {
                Categories = categories,
                Products = products
            };

            return this.View(model);
        }
    }
}