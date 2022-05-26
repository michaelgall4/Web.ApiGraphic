using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppGraphic.Models;

namespace WebAppGraphic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _client;
        public string Message { get; set; }

        public IEnumerable<Product.Api.Models.ProductDto> ProductList { get; set; }

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var client = _client.CreateClient("ProductApi");
            Message = await client.GetStringAsync("Product/List");
            ProductList = await client.GetFromJsonAsync<IEnumerable<Product.Api.Models.ProductDto>>("Product/List");
            return View(ProductList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}