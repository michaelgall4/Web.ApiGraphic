using Microsoft.AspNetCore.Mvc;
using Product.Api.Models;
using Product.Api.SQL;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route(template: "Product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductDataProvider _productDataProvider;

        public ProductController(ILogger<ProductController> logger, IProductDataProvider productDataProvider)
        {
            _logger = logger;
            _productDataProvider = productDataProvider;
        }

        [HttpGet(template: "{Id}")]
        public ProductDto Get(int Id)
        {
            return _productDataProvider.GetById(Id);
        }

        [HttpPut(template: "Add")]
        public void Add(ProductDto product)
        {
            _productDataProvider.Add(product);
        }

        [HttpPost(template: "Edit")]
        public void Edit(ProductDto product)
        {
            _productDataProvider.Edit(product);
        }

        [HttpDelete(template: "Delete")]
        public void Delete(int id)
        {
            _productDataProvider.Delete(id);
        }

        [HttpGet(template: "List")]
        public IEnumerable<ProductDto> GetList(int? number)
        {
            if (number == null)
                return _productDataProvider.GetAll();

            return _productDataProvider.GetMany(number.GetValueOrDefault());
        }


    }
}