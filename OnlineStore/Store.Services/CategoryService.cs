namespace Store.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public class CategoryService
    {
        public List<Category> Get()
        {
            using (StoreContext ctx = new StoreContext())
            {
                return ctx.Categories.ToList();
            }
        }
    }
}
