using Cart.Api.Models;
using Cart.Api.SQL;
using System.Data.SqlClient;

namespace Cart.Api.SQLCart
{
    public class CartDataProvider : ICartDataProvider
    {
        private readonly string _connectionString;

        public CartDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CheckExist(CartDto cart)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"select count(*)
                       from Cart
                       where UserId = @UserId and ProductId = @ProductId";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserId", cart.UserId);
            command.Parameters.AddWithValue("ProductId", cart.ProductId);

            return Convert.ToInt32(command.ExecuteScalar()) == 1;

        }

        public void Add(CartDto cart)
        {

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"insert into Cart ([UserId],[ProductId],[Quantity])
                        values(@UserId, @ProductId, @Quantity)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserId", cart.UserId);
            command.Parameters.AddWithValue("ProductId", cart.ProductId);
            command.Parameters.AddWithValue("Quantity", cart.Quantity);

            command.ExecuteNonQuery();
        }

        public void Update(CartDto cart)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"UPDATE [dbo].[Cart]
                         SET [Quantity] =  @Quantity
                         WHERE ProductId=@ProductId and UserId=@UserId;";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserId", cart.UserId);
            command.Parameters.AddWithValue("ProductId", cart.ProductId);
            command.Parameters.AddWithValue("Quantity", cart.Quantity);


            command.ExecuteNonQuery();
        }

        public IEnumerable<CartDto> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT [Id], [Name], [Price], [Quantity], [Description] FROM Product; ";
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CartDto
                {
                    IdCart = int.Parse(reader["ID"].ToString()),
                    UserId = int.Parse(reader["ID"].ToString()),
                    ProductId = int.Parse(reader["ID"].ToString()),
                    Quantity = int.Parse(reader["ID"].ToString())

                };
            }
        }

        public CartDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
