namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double Quantity { get; set; }

        //Warranty in months
        public int Warranty { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string PicturePath { get; set; }
    }
}
