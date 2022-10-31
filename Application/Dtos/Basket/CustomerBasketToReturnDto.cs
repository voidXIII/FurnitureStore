namespace Application.Dtos.Basket
{
    public class CustomerBasketToReturnDto
    {
        public string Id { get; set; }
        public List<CustomerBasketItemsToReturnDto> Items { get; set; }
    }
}