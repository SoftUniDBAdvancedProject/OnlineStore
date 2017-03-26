namespace Store.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels;

    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();

            vm.HandleRequest();

            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Index(ProductViewModel vm)
        {
            if (vm.File != null)
            {
                byte[] uploadedFile = new byte[vm.File.InputStream.Length];
                vm.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
            }

            vm.IsValid = this.ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                this.ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    this.ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return this.View(vm);
        }
    }
}
