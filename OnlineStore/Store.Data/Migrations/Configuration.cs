namespace Store.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Serialization;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Store.Data.StoreContext";
        }

        protected override void Seed(StoreContext context)
        {
            this.SeedAdmin(context);
            this.SeedCountries(context);
            this.SeedCategories(context);
            this.SeedProducts(context);
        }

        private void SeedProducts(StoreContext context)
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Harry Potter and The Deathly Hallows",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Ireland"),
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Ireland").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives").Id,
                    Price = 20,
                    Description =
                        "Harry Potter and the Deathly Hallows is the final book of the LEGENDARY collection Harry Potter by JK Rowling",
                    Quantity = 100,
                    PicturePath = "HarryPotterAndTheDeathlyHallows.jpg"
                },
                new Product()
                {
                    Name = "It",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Ireland"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Ireland").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives").Id,
                    Price = 19.99m,
                    Description = "Stephen King's IT is a best-seller.",
                    Quantity = 150,
                    PicturePath = "StephenKingIt.jpg"
                },
                new Product()
                {
                    Name = "Hunger Games (All Books)",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Ireland"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Ireland").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Books and consumptives").Id,
                    Price = 20,
                    Description =
                        "Harry Potter and the Deathly Hallows is the final book of the LEGENDARY collection Harry Potter",
                    Quantity = 100,
                    PicturePath = "HarryPotterAndTheDeathlyHallows.jpg"
                },
                new Product()
                {
                    Name = "Alienware 17 inches",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Japan"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Japan").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery").Id,
                    Price = 4999,
                    Description = "Alienware is one of the best brands for GAMING Laptops in the WORLD",
                    Quantity = 20,
                    Warranty = 36,
                    PicturePath = "alienware.jpg"
                },
                new Product()
                {
                    Name = "Acer Predator G9 15,6 inches",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Belgium"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery").Id,
                    Price = 2000,
                    Description =
                        "Acer Predator is a very good gaming laptop for any type of game! And it's very cheap for it's characteristics",
                    Quantity = 25,
                    PicturePath = "acer-predator-g9.jpg"
                },
                new Product()
                {
                    Name = "Lenovo IDEAPAD 300 15,6 INCHES",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery"),
                      CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Computers and Periphery").Id,
                    Price = 999.99m,
                    Description = "A very good LAPTOP for everything. I7 processor. Gotta lovei t",
                    Quantity = 10,
                    PicturePath = "lenovo_ideapad_300.png"
                },
                new Product()
                {
                    Name = "Laundry",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances"),
                      CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances").Id,
                    Price = 200,
                    Description = "A very good laundry",
                    Quantity = 100,
                    PicturePath = "laundry.png"
                },
                new Product()
                {
                    Name = "Stove",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances"),
                      CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances").Id,
                    Price = 250,
                    Description = "A very good stove",
                    Quantity = 100,
                    PicturePath = "stove.png"
                },
                new Product()
                {
                    Name = "TV",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Electric Appliances").Id,
                    Price = 1000,
                    Description = "A very good TV",
                    Quantity = 10,
                    PicturePath = "TV.png"
                },
                new Product()
                {
                    Name = "Jeans",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Fashion"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Fashion").Id,
                    Price = 60,
                    Description = "Very good jeans",
                    Quantity = 100,
                    PicturePath = "jeans.jpg"
                },
                new Product()
                {
                    Name = "T-shirt",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                      CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Fashion"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Fashion").Id,
                    Price = 20,
                    Description = "Very good t-shirt",
                    Quantity = 100,
                    PicturePath = "t-shirt.png"
                },
                new Product()
                {
                    Name = "Table",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture").Id,
                    Price = 140.99m,
                    Description = "Very good table",
                    Quantity = 100,
                    PicturePath = "table.jpg"
                },
                new Product()
                {
                    Name = "Bedchamber for Couple",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture").Id,
                    Price = 239.99m,
                    Description = "Very good bed chamber for a lovely couple",
                    Quantity = 100,
                    PicturePath = "bedchamber.jpg"
                },
                new Product()
                {
                    Name = "Caterpillar",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec").Id,
                    Price = 209.99m,
                    Description = "Very good phone for angry people!",
                    Quantity = 100,
                    PicturePath = "caterpillar.jpg"
                },
                new Product()
                {
                    Name = "Huawei P10",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec").Id,
                    Price = 609.99m,
                    Description = "Very good phone for cool people!",
                    Quantity = 100,
                    PicturePath = "huaweiP10.jpg"
                },
                new Product()
                {
                    Name = "Iphone 7 PLUS Rose Gold",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Mobile Devicec").Id,
                    Price = 1449.99m,
                    Description = "Very good phone for rich people!",
                    Quantity = 100,
                    PicturePath = "iphone7_rose_gold_128gb.jpg"
                },
                new Product()
                {
                    Name = "Nikon",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video").Id,
                    Price = 1449.99m,
                    Description = "Very good camera.",
                    Quantity = 100,
                    PicturePath = "nikon.jpg"
                },
                new Product()
                {
                    Name = "Fujifilm",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video").Id,
                    Price = 1649.99m,
                    Description = "Very good camera.",
                    Quantity = 100,
                    PicturePath = "fujifilm.jpg"
                },
                new Product()
                {
                    Name = "Canon",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Photo and Video").Id,
                    Price = 1949.99m,
                    Description = "Very good camera.",
                    Quantity = 100,
                    PicturePath = "canon-slr.jpg"
                },
                new Product()
                {
                    Name = "Basket ball",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Sport"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Sport").Id,
                    Price = 59.99m,
                    Description = "Very good ball.",
                    Quantity = 100,
                    PicturePath = "basket-ball.jpg"
                },
                new Product()
                {
                    Name = "Football ball",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Sport"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Sport").Id,
                    Price = 59.99m,
                    Description = "Very good ball.",
                    Quantity = 100,
                    PicturePath = "foot-ball.jpg"
                },
                new Product()
                {
                    Name = "Golf stick",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Sport"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Sport").Id,
                    Price = 159.99m,
                    Description = "Very good stick.",
                    Quantity = 100,
                    PicturePath = "golf-stick.jpg"
                },
                new Product()
                {
                    Name = "ATV for Kids",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Toys"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Toys").Id,
                    Price = 79.99m,
                    Description = "Very good ATV for kids.",
                    Quantity = 100,
                    PicturePath = "kids-ride-atv.jpg"
                },
                new Product()
                {
                    Name = "Real Steal Robots",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Toys"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Toys").Id,
                    Price = 79.99m,
                    Description = "Toy Robots for kids.",
                    Quantity = 100,
                    PicturePath = "real-steal.jpg"
                },
                new Product()
                {
                    Name = "Trucks",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Toys"),
                     CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Toys").Id,
                    Price = 39.99m,
                    Description = "Toy Robots for kids.",
                    Quantity = 100,
                    PicturePath = "trucks_allcolors.jpg"
                },
                new Product()
                {
                    Name = "Stool",
                    Country = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong"),
                     CountryId = context.Countries.FirstOrDefault(c => c.Name == "Hong Kong").Id,
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture"),
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Home and Furniture").Id,
                    Price = 39.99m,
                    Description = "Very good stool",
                    Quantity = 100,
                    PicturePath = "stool.jpg"
                }
            };

            foreach (var product in products)
            {
                context.Products.AddOrUpdate(c => c.Name, product);
            }

            context.SaveChanges();
        }

        private void SeedCategories(StoreContext context)
        {
            var books = new Category()
            {
                Name = "Books and consumptives",
                PicturePath = "books-and-consumptives.png"
            };

            var pc = new Category()
            {
                Name = "Computers and Periphery",
                PicturePath = "computers-and-periphery.png"
            };

            var electric = new Category()
            {
                Name = "Electric Appliances",
                PicturePath = "electric-appliances.png"
            };

            var fash = new Category()
            {
                Name = "Fashion",
                PicturePath = "fashion.png"
            };

            var home = new Category()
            {
                Name = "Home and Furniture",
                PicturePath = "home-furniture.png"
            };

            var mobile = new Category()
            {
                Name = "Mobile Devicec",
                PicturePath = "mobile-devicec.png"
            };

            var photo = new Category()
            {
                Name = "Photo and Video",
                PicturePath = "photo.png"
            };

            var sport = new Category()
            {
                Name = "Sport",
                PicturePath = "sports.png"
            };

            var toys = new Category()
            {
                Name = "Toys",
                PicturePath = "toys.png"
            };

            context.Categories.AddOrUpdate(c => c.Name, toys, sport, photo, mobile, home, fash, electric, pc, books);
            context.SaveChanges();
        }

        private void SeedCountries(StoreContext context)
        {
            string path = HttpContext.Current.Server.MapPath(@"/Content/DataImports/countries.json");
            using (StreamReader reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                var countries = serializer.Deserialize<List<Country>>(json);
                foreach (var country in countries)
                {
                    context.Countries.AddOrUpdate(c => c.Name, country);
                }

                context.SaveChanges();
            }
        }

        private void SeedAdmin(StoreContext context)
        {
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "admin@gmail.com", Email = "admin@gmail.com" };

                userManager.Create(userToInsert, "123456");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }
        }
    }
}
