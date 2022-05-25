using Microsoft.AspNetCore.Mvc;
using Cart.Api.Models;
using Cart.Api.SQL;

namespace Cart.Api.Controllers
{
    [ApiController]
    [Route(template: "Cart")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICartDataProvider _cartDataProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICartDataProvider cartDataProvider)
        {
            _cartDataProvider = cartDataProvider;
           _logger = logger;
        }

        [HttpGet(template: "{Id}")]
        public CartDto Get(int Id)
        {
            return _cartDataProvider.GetById(Id);
        }
        [HttpPut(template: "Add")]
        public void Add( CartDto cart)
        {
           if(_cartDataProvider.Check(cart))
            {
                _cartDataProvider.Update(cart);
               
            }
            else
            {
                _cartDataProvider.Add(cart);
            }
        }

        

    }
}