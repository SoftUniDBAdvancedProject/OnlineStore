namespace Store.Data.Migrations
{
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

            context.Categories.AddOrUpdate(c=>c.Name, toys,sport,photo,mobile,home,fash,electric,pc,books);
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
                var role = new IdentityRole {Name = "User"};
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole {Name = "Admin"};
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User {UserName = "admin@gmail.com", Email = "admin@gmail.com"};

                userManager.Create(userToInsert, "123456");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }
        }
    }
}
