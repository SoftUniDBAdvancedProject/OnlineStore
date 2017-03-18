namespace Store.Models
{
    using Enums;

    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public AddressType AddressType { get; set; }
    }
}
