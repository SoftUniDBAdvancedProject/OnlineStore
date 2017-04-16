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
        public ActionResult Index(int page = 1, int count = 6, string category = null)
        {
            var managerProducts = new ProductService();
            var managerCategories = new CategoryService();

            var products = managerProducts.Get();
            var categories = managerCategories.Get();
            if (category !=null)
            {
                products = products.Where(p => p.Category.Name == category).ToList();
            }

            int productsCount = products.Count;
            products = products.Skip((page - 1) * count)
                .Take(count)
                .ToList();
            
            this.ViewBag.TotalPages = (productsCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;
            this.ViewBag.CurrentCategory = category;

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