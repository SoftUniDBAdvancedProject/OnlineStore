namespace Store.Models
{
    public class CartProduct
    {
        public string CartId { get; set; }

        public string ProductId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }

        public double Quantity { get; set; }
    }
}
