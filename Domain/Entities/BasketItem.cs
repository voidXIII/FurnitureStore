namespace Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public string productName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Topology { get; set; }
    }
}