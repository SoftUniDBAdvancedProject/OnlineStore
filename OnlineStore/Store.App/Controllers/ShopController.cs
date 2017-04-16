namespace Store.App.Controllers
{
    using System.Linq;
    using Services;
    using ViewModels;
    using System.Web.Mvc;
    using Store.Models;

    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(string category = null)
        {
            var managerProducts = new ProductService();
            var managerCategories = new CategoryService();

            var products = managerProducts.Get();
            var categories = managerCategories.Get();
            if (category !=null)
            {
                products = products.Where(p => p.Category.Name == category).ToList();
            }

            var model = new ShopViewModel
            {
                Categories = categories,
                Products = products
            };

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var managerProducts = new ProductService();
            var product = managerProducts.Get(id);

            return this.View(product);
        }
    }
}