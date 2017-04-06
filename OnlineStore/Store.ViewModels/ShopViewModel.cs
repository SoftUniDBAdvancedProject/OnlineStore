using Store.Models;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Store.ViewModels
{
    public class ShopViewModel : BaseViewModel
    {
        public ShopViewModel() 
        {
            this.Categories = new HashSet<Category>();
            this.Products = new HashSet<Product>();
        }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }




        public Product SearchEntity { get; set; }

        public Product Entity { get; set; }


        public HttpPostedFileBase File { get; set; }
        public string PicturePath
        {
            get
            {
                
                string nameAndLocation = "/Content/Images/Products/";
                return nameAndLocation;
            }
        }

        protected override void ResetSearch()
        {
            this.SearchEntity = new Product();

            base.ResetSearch();
        }


        protected override void Get()
        {
            ProductService mgr = new ProductService();

            this.Products = mgr.Get(this.SearchEntity).OrderByDescending(p => p.Id).ToList();

            base.Get();
        }
    }
}
