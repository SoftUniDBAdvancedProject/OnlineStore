namespace Store.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
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
            List<Product> ret;

            using (StoreContext ctx = new StoreContext())
            {
                ret = ctx.Products.ToList();
            }

            if (!string.IsNullOrEmpty(entity.Name))
            {
                ret = ret.FindAll(p => p.Name.ToLower().Contains(entity.Name.ToLower()) || p.Description.ToLower().Contains(entity.Name.ToLower()));
            }

            return ret;
        }

        public Product Get(int productId)
        {
            Product ret;

            using (StoreContext ctx = new StoreContext())
            {
                ret = ctx.Products.Find(productId);
            }

            return ret;
        }

        public bool Update(Product entity)
        {
            bool ret = false;

            ret = this.Validate(entity);

            if (ret)
            {
                using (var context = new StoreContext())
                {
                    context.Products.Attach(entity);
                    var entry = context.Entry(entity);
                    entry.Property(e => e.Name).IsModified = true;
                    entry.Property(e => e.PicturePath).IsModified = true;
                    entry.Property(e => e.Price).IsModified = true;
                    entry.Property(e => e.Quantity).IsModified = true;
                    entry.Property(e => e.Warranty).IsModified = true;
                    entry.Property(e => e.CategoryId).IsModified = true;
                    entry.Property(e => e.CountryId).IsModified = true;
                    context.SaveChanges();
                }
            }

            return ret;
        }

        public bool Delete(Product entity)
        {
            using (StoreContext ctx = new StoreContext())
            {
                var prod = ctx.Products.Find(entity.Id);
                if (prod != null)
                {
                    ctx.Products.Remove(prod);
                    ctx.SaveChanges();
                }
            }

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
                using (StoreContext ctx = new StoreContext())
                {
                    ctx.Products.Add(entity);

                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            return ret;
        }
    }
}
