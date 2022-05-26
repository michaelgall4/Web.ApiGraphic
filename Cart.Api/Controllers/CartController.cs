using Microsoft.AspNetCore.Mvc;
using Cart.Api.Models;
using Cart.Api.SQL;

namespace Cart.Api.Controllers
{
    [ApiController]
    [Route(template: "Cart")]
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;
        private readonly ICartDataProvider _cartDataProvider;

        public CartController(ILogger<CartController> logger, ICartDataProvider cartDataProvider)
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
        public void Add(CartDto cart)
        {
            if (_cartDataProvider.CheckExist(cart))
                _cartDataProvider.Update(cart);
            else
                _cartDataProvider.Add(cart);
        }

    }
}