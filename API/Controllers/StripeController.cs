using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace API.Controllers
{
    public class StripeController : BaseApiController
    {
        private readonly IStripeService _stripeService;
        private const string WhSecret = "whsec_0bb033fd55d469377999b88279649490f468bc2b44f01cca47c6a390edad023f";
        private readonly ILogger<StripeController> _logger;
        public StripeController(IStripeService stripeService, ILogger<StripeController> logger)
        {
            _logger = logger;
            _stripeService = stripeService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> AddOrUpdateStripeIntent(string basketId)
        {
            var basket = await _stripeService.AddOrUpdateStripeIntent(basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "Your basket has a problem"));
            
            return basket;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);

            PaymentIntent intent;
            Order order;

            switch(stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent) stripeEvent.Data.Object;
                    _logger.LogInformation("Payment Succeeded: ", intent.Id);
                    order = await _stripeService.UpdateOrderPaymentSucceeded(intent.Id);
                    _logger.LogInformation("Order updated to payment received: ", order.Id);
                    break;
                case "payment_intent.payment_failed":
                    intent = (PaymentIntent) stripeEvent.Data.Object;
                    order = await _stripeService.UpdateOrderPaymentFailed(intent.Id);
                    _logger.LogInformation("Payment failed: ", order.Id);
                    break;
            }
            return new EmptyResult();
        }

    }
}