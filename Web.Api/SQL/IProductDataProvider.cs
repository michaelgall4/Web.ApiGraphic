using Web.Api.Models;

namespace Web.Api.SQL
{
    public interface IProductDataProvider
    {
        public Product GetProductById(int id);
    }
}
