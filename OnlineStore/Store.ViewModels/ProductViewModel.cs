namespace Store.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Services;

    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
      : base()
        {
            // Initialize other variables
            this.Products = new List<Product>();
            this.SearchEntity = new Product();
            this.Entity = new Product();
        }

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

        public override void HandleRequest()
        {
            // This is an example of adding on a new command
            switch (this.EventCommand.ToLower())
            {
                case "newcommand":
                    break;

            }

            base.HandleRequest();
        }

        protected override void Add()
        {
            this.IsValid = true;

            // Initialize Entity Object
            this.Entity = new Product();

            base.Add();
        }

        protected override void Edit()
        {
            ProductService mgr =
             new ProductService();

            // Get Product Data
            this.Entity = mgr.Get(
              Convert.ToInt32(this.EventArgument));

            base.Edit();
        }

        protected override void Save()
        {
            ProductService mgr =
              new ProductService();

            if (this.Mode == "Add")
            {
                mgr.Insert(this.Entity);
            }
            else
            {
                mgr.Update(this.Entity);
            }

            // Set any validation errors
            this.ValidationErrors = mgr.ValidationErrors;

            // Set mode based on validation errors
            base.Save();
        }

        protected override void Delete()
        {
            ProductService mgr =
              new ProductService();

            // Create new entity
            this.Entity = new Product();

            // Get primary key from EventArgument
            this.Entity.Id =
              Convert.ToInt32(this.EventArgument);

            // Call data layer to delete record
            mgr.Delete(this.Entity);

            // Reload the Data
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
