namespace Store.Models
{
    using System.Collections.Generic;

    public class Order
    {
        private ICollection<OrderProduct> products;

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderProduct> Products => this.products ?? (this.products = new HashSet<OrderProduct>());
    }
}
