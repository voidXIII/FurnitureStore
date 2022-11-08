namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Model { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int TopologyId { get; set; }
        public Topology Topology {get; set; }
        public int FunctionId { get; set; }
        public Function Function { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
    }
}