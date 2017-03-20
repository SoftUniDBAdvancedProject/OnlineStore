namespace Store.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Services;

    public class ProductViewModel : BaseViewModel
    {
        public List<Product> Products { get; set; }

        public Product SearchEntity { get; set; }

        public Product Entity { get; set; }

        protected override void Init()
        {
            this.Products = new List<Product>();
            this.SearchEntity = new Product();
            this.Entity = new Product();

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

            if (this.Mode == "Add")
            {
                mgr.Insert(this.Entity);
            }
            else
            {
                mgr.Update(this.Entity);
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
    }
}
