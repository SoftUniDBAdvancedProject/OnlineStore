namespace Store.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using Services;

    public class ProductViewModel : BaseViewModel
    {
        public List<Product> Products { get; set; }

        public Product SearchEntity { get; set; }

        public Product Entity { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Countries { get; set; }

        protected override void Init()
        {
            this.Products = new List<Product>();
            this.SearchEntity = new Product();
            this.Entity = new Product();
            this.InitDependancies();

            base.Init();
        }

        protected override void Add()
        {
            this.IsValid = true;

            this.Entity = new Product();

            base.Add();
        }

        protected override void Edit()
        {
            ProductService mgr = new ProductService();
            this.Entity = mgr.Get(Convert.ToInt32(this.EventArgument));

            base.Edit();
        }

        protected override void Save()
        {
            ProductService mgr = new ProductService();
            if (this.IsValid)
            {
                if (this.Mode == "Add")
                {
                    mgr.Insert(this.Entity);
                }
                else
                {
                    mgr.Update(this.Entity);
                }
            }

            this.ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        protected override void Delete()
        {
            ProductService mgr = new ProductService();

            this.Entity = new Product();

            this.Entity.Id = Convert.ToInt32(this.EventArgument);

            mgr.Delete(this.Entity);

            this.Get();

            base.Delete();
        }

        protected override void ResetSearch()
        {
            this.SearchEntity = new Product();

            base.ResetSearch();
        }

        protected override void Get()
        {
            ProductService mgr = new ProductService();

            this.Products = mgr.Get(this.SearchEntity);

            base.Get();
        }

        private void InitDependancies()
        {
            if (this.Categories == null)
            {
                var catService = new CategoryService();
                this.Categories = catService.Get().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }

            if (this.Countries == null)
            {
                var countryService = new CountryService();
                this.Countries = countryService.Get().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
        }
    }
}
