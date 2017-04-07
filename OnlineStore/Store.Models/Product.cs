namespace Store.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ConcurrencyCheck]
        public double Quantity { get; set; }

        public int Warranty { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string PicturePath { get; set; }

        [NotMapped]
        public string FullPicturePath { get { return $"{this.Category.Name}/{this.PicturePath}"; } }
    }
}
