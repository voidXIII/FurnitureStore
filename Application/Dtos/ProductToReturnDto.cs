namespace Application.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Topology {get; set; }
        public string Function { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
    }
}