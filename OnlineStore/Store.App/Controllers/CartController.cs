using Microsoft.AspNet.Identity;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Store.App.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var products = this.Data.Products.Where(c => c.Quantity > 0).ToList();
            return View(products);
        }

        public CartController(Context data) : base(data)
        {

        }

        [Authorize]
        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this.Data.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            var cartProduct = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
               PicturePath = product.PicturePath,
                Quantity = product.Quantity
            };

            return this.View(cartProduct);
        }


        [Authorize]
        public ActionResult MyCart()
        {
            string currentUserId = this.User.Identity.GetUserId();
            var cart = this.Data.Carts.FirstOrDefault(u => u.User.Id == currentUserId);

            if (cart == null || cart.Products.Count == 0)
            {
                return this.View("EmptyCart");
            }

            var products = cart.Products.ToList();
            

            return this.View(products);
        }
    }
}