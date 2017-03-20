namespace Store.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class ProductService
    {
        public ProductService()
        {
            this.ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public List<Product> Get()
        {
            return this.Get(new Product());
        }

        public List<Product> Get(Product entity)
        {
            List<Product> ret = new List<Product>();

            // TODO: Add your own data access method here
            ret = this.CreateMockData();

            // Do any searching
            if (!string.IsNullOrEmpty(entity.Name))
            {
                ret = ret.FindAll(
                  p => p.Name.ToLower().
                        StartsWith(entity.Name,
                                  StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }

        public Product Get(int productId)
        {
            List<Product> ret =
              new List<Product>();
            Product entity = null;

            // TODO: Add data access method here
            ret = this.CreateMockData();

            // Find the specific product
            entity = ret.Find(p =>
               p.Id == productId);

            return entity;
        }

        public bool Update(Product entity)
        {
            bool ret = false;

            ret = this.Validate(entity);

            if (ret)
            {
                // TODO: Create UPDATE code here
            }

            return ret;
        }

        public bool Delete(Product entity)
        {
            // TODO: Create DELETE code here
            return true;
        }

        public bool Validate(Product entity)
        {
            this.ValidationErrors.Clear();

            if (!string.IsNullOrEmpty(entity.Name))
            {
                if (entity.Name.ToLower() ==
                    entity.Name)
                {
                    this.ValidationErrors.Add(new
                      KeyValuePair<string, string>("ProductName",
                      "Product must not be all lower case."));
                }
            }

            return (this.ValidationErrors.Count == 0);
        }

        public bool Insert(Product entity)
        {
            bool ret = false;

            ret = this.Validate(entity);

            if (ret)
            {
                /// TODO: Create INSERT code here
            }

            return ret;
        }

        protected List<Product> CreateMockData()
        {
            var products = new List<Product>
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

            return products;
        }
    }
}
