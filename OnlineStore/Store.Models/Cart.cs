namespace Store.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        private ICollection<CartProduct> products;

        public int Id { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<CartProduct> Products => this.products ?? (this.products = new HashSet<CartProduct>());
    }
}
