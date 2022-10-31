using Application.Dtos.Basket;

namespace Application.Interfaces
{
    public interface IBasketService
    {
        Task<CustomerBasketToReturnDto> GetBasketByIdAsync(string id);
        Task<CustomerBasketToReturnDto> CreateOrUpdateBasketAsync(CustomerBasketCreateOrUpdateDTO basket);
        Task DeleteBasketByIdAsync(string id);
    }
}