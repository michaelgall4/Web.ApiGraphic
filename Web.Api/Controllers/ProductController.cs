using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;
using Web.Api.SQL;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route(template: "Product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductDataProvider _productDataProvider;

        public ProductController(ILogger<ProductController> logger, IProductDataProvider productDataProvider)
        {
            _logger = logger;
            _productDataProvider = productDataProvider;
        }

        [HttpGet(template: "{Id}")]
        public Product Get(int Id)
        {
            return _productDataProvider.GetProductById(Id);
        }
    }
}