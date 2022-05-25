using Product.Api.Models;

namespace Product.Api.SQL
{
    public interface IProductDataProvider
    {
        public ProductDto GetById(int id);
        public void Add(ProductDto product);
        public void Edit(ProductDto product);
        public void Delete(int id);
        public IEnumerable<ProductDto> GetMany(int limit);
        public IEnumerable<ProductDto> GetAll();
    }
}
