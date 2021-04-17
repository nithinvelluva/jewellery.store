﻿using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jewellery.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCalculatorController : ControllerBase
    {
        private readonly IPriceCalculatorService _priceCalculatorService;
        public PriceCalculatorController(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }

        // POST: api/PriceCalculator
        [HttpPost]
        public PriceCalculatorResponse Post(PriceRequest request)
        {
            var result = _priceCalculatorService.CalculatePrice(request);
            return result;
        }
    }
}
