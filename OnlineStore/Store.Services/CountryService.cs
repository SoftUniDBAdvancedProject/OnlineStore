namespace Store.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public class CountryService
    {
        public List<Country> Get()
        {
            using (StoreContext ctx = new StoreContext())
            {
                return ctx.Countries.ToList();
            }
        }
    }
}
