namespace Application.Dtos.Basket
{
    public class CustomerBasketCreateOrUpdateDTO
    {
        public string Id { get; set; }
        public List<CustomerBasketItemsToReturnDto> Items { get; set; }
    }
}