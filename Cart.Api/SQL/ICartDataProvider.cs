using Cart.Api.Models;

namespace Cart.Api.SQL
{
    public interface ICartDataProvider
    {
        public IEnumerable<CartDto> GetByUserId(int userId);
        public IEnumerable<CartDto> GetAll();
        public bool CheckExist(CartDto cart);
        public void Update(CartDto cart);
        public void Add(CartDto cart);
        public void Delete(int userId, int productId);

    }
}
