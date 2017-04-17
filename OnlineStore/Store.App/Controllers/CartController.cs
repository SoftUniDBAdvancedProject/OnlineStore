using Microsoft.AspNet.Identity;
using Store.Data;
using Store.Models;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Store.App.Controllers
{
    using System.Data.Entity;

    [Authorize]
    public class CartController : BaseController
    {
        public CartController(Context data) : base(data)
        {
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = this.GetCartOfCurrentUser();

            if (cart.Products.Count == 0)
            {
                return this.View("EmptyCart");
            }

            return this.View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            Product product = this.Data.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            var cart = this.GetCartOfCurrentUser();
            var cartProduct = cart.Products.FirstOrDefault(cp => cp.ProductId == id);

            if (cartProduct == null)
            {
                cartProduct = new CartProduct
                {
                    ProductId = id,
                    Cart = cart,
                    Quantity = 0
                };
            }

            cartProduct.Quantity++;

            cart.Products.Add(cartProduct);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = this.GetCartOfCurrentUser();
            var cartProduct = cart.Products.FirstOrDefault(cp => cp.ProductId == id);
            cart.Products.Remove(cartProduct);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }

        public ActionResult FinalizePurchase(int cartId)
        {
            var cart = this.GetCartOfCurrentUser();
            if (cart.Products.Count == 0)
            {
                return this.RedirectToAction("Index");
            }

            foreach (var product in cart.Products)
            {
                var soldProduct = this.Data.Products.FirstOrDefault(p => p.Id == product.ProductId);
                if (soldProduct == null)
                {
                    cart.Products.Remove(product);
                    return this.RedirectToAction("Index");
                }
                
                if (soldProduct.Quantity - product.Quantity < 0)
                {
                    product.Quantity = soldProduct.Quantity;
                    return this.RedirectToAction("Index");
                }
            }

          
            var order = new Order() { UserId = this.UserProfile.Id };
            foreach (var product in cart.Products)
            {
                var soldProduct = this.Data.Products.FirstOrDefault(p => p.Id == product.ProductId);
                soldProduct.Quantity -= product.Quantity;
                var orderedProduct = new OrderProduct()
                {
                    Product = soldProduct,
                    Quantity = product.Quantity,
                    Order = order
                };

                order.Products.Add(orderedProduct);
            }

            cart.Products.Clear();
            this.Data.SaveChanges();

            return this.View(order);
        }

        private Cart GetCartOfCurrentUser()
        {
            var cart = this.Data.Carts.Include(c => c.Products).FirstOrDefault(c => c.User.Id == this.UserProfile.Id);
            if (cart == null)
            {
                cart = new Cart();
                this.UserProfile.Cart = cart;
            }

            return cart;
        }
    }
}