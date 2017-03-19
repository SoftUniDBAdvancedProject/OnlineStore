namespace Store.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using App.Controllers;
    using Data;
    using Store.Models;

    public class HomeController : BaseController
    {
        // GET: Admin/Products
        public HomeController(Context data) : base(data)
        {
        }

        public async Task<ActionResult> Index()
        {
            //var products = this.Data.Products.Include(p => p.Category).Include(p => p.Country);
            //return View(await products.ToListAsync());

            //TODO: Remove test data
            var products = new List<Product>()
            {
                new Product()
                {
                   Category = new Category()
                    {
                       Name = "Cat1"
                    },
                   Country = new Country() {Name = "BG"},
                   Name = "prod1",
                   Description = "tova e product 1",
                   Price = 200m,
                   Quantity = 69,
                   Warranty = 24
                },
                new Product()
                {
                   Category = new Category()
                    {
                       Name = "Cat2"
                    },
                   Country = new Country() {Name = "BG"},
                   Name = "prod2",
                   Description = "tova e product 2",
                   Price = 200m,
                   Quantity = 69,
                   Warranty = 24
                },
                new Product()
                {
                   Category = new Category()
                    {
                       Name = "Cat3"
                    },
                   Country = new Country() {Name = "BG"},
                   Name = "prod3",
                   Description = "tova e product 3",
                   Price = 200m,
                   Quantity = 69,
                   Warranty = 24
                }
            };
            return this.View(products);
        }

        // GET: Admin/Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.Data.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.Data.Categories, "Id", "Name");
            ViewBag.CountryId = new SelectList(this.Data.Countries, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Quantity,Warranty,CountryId,CategoryId,PicturePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.Data.Products.Add(product);
                await this.Data.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories, "Id", "Name", product.CategoryId);
            ViewBag.CountryId = new SelectList(this.Data.Countries, "Id", "Name", product.CountryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.Data.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(this.Data.Categories, "Id", "Name", product.CategoryId);
            ViewBag.CountryId = new SelectList(this.Data.Countries, "Id", "Name", product.CountryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,Quantity,Warranty,CountryId,CategoryId,PicturePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.Data.Entry(product).State = EntityState.Modified;
                await this.Data.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(this.Data.Categories, "Id", "Name", product.CategoryId);
            ViewBag.CountryId = new SelectList(this.Data.Countries, "Id", "Name", product.CountryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.Data.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await this.Data.Products.FindAsync(id);
            this.Data.Products.Remove(product);
            await this.Data.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
