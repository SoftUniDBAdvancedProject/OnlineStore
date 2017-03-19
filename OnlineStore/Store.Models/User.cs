namespace Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Addresses = new HashSet<Address>();
        }
        public virtual Cart Cart { get; set; }

        public int? CartId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
