using Cart.Api.Models;

namespace Cart.Api.SQL
{
    public interface ICartDataProvider
    {
        public CartDto GetById(int id);
        public bool CheckExist(CartDto cart);
        public void Update(CartDto cart);
        public void Add(CartDto cart);

    }
}
