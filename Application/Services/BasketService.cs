using Application.Dtos.Basket;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasketToReturnDto> CreateOrUpdateBasketAsync(CustomerBasketCreateOrUpdateDTO basket)
        {
            var basketToUpdate = new CustomerBasket();
            var dataToUpdate = _mapper.Map(basket, basketToUpdate);
            var updatedBasket =  await _basketRepository.UpdateBasketAsync(dataToUpdate);
            return _mapper.Map<CustomerBasketToReturnDto>(updatedBasket);
        }

        public async Task DeleteBasketByIdAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }

        public async Task<CustomerBasketToReturnDto> GetBasketByIdAsync(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return _mapper.Map<CustomerBasketToReturnDto>(basket);
        }
    }
}