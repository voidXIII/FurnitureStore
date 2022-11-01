namespace Application.Dtos.Basket
{
    public class CustomerBasketItemsToReturnDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string RoomPictureUrl { get; set; }
        public string Type { get; set; }
    }
}