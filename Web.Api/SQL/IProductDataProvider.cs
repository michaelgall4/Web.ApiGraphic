using Web.Api.Models;

namespace Web.Api.SQL
{
    public interface IProductDataProvider
    {
        public Product GetById(int id);
        public void Add(Product product);
        public void Edit(Product product);
        public void Delete(int id);
        public IEnumerable<Product> GetMany(int limit);
        public IEnumerable<Product> GetAll();
    }
}
