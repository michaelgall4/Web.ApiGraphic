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
            return _productDataProvider.GetById(Id);
        }

        [HttpPut(template: "Add")]
        public void Add(Product product)
        {
            _productDataProvider.Add(product);
        }

        [HttpPost(template: "Edit")]
        public void Edit(Product product)
        {
            _productDataProvider.Edit(product);
        }

        [HttpDelete(template: "Delete")]
        public void Delete(int id)
        {
            _productDataProvider.Delete(id);
        }

        [HttpGet(template: "List")]
        public IEnumerable<Product> GetList(int? number)
        {
            if (number == null)
                return _productDataProvider.GetAll();

            return _productDataProvider.GetMany(number.GetValueOrDefault());
        }


    }
}