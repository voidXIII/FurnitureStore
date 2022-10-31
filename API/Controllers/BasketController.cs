using Application.Dtos.Basket;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketToReturnDto>> GetBasketById(string id)
        {
            var result = await _basketService.GetBasketByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketItemsToReturnDto>> UpdateBasket(CustomerBasketCreateOrUpdateDTO basket)
        {
            var result = await _basketService.CreateOrUpdateBasketAsync(basket);
            return Ok(result);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketService.DeleteBasketByIdAsync(id);
        }
    }
}