namespace Store.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Order> orders;

        private ICollection<Address> addresses;

        public int? CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders => this.orders ?? (this.orders = new HashSet<Order>());

        public virtual ICollection<Address> Addresses => this.addresses ?? (this.addresses = new HashSet<Address>());

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
