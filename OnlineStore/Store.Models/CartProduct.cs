using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class CartProduct
    {
        public virtual Cart Cart { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double Quantity { get; set; }
    }
}
