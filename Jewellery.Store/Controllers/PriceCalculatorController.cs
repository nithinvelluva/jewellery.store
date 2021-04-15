using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.Services;
using Microsoft.AspNetCore.Http;
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

        // GET: api/PriceCalculator/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PriceCalculator
        [HttpPost]
        public IActionResult Post(PriceRequest request)
        {
            var result = _priceCalculatorService.CalculatePrice(request);
            return new JsonResult(result);
        }
    }
}
