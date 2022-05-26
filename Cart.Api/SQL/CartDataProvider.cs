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
            var query = "SELECT * FROM Cart";
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CartDto
                {
                    IdCart = int.Parse(reader["IdCart"].ToString()),
                    UserId = int.Parse(reader["UserId"].ToString()),
                    ProductId = int.Parse(reader["ProductId"].ToString()),
                    Quantity = int.Parse(reader["Quantity"].ToString())

                };
            }
        }

        public IEnumerable<CartDto> GetByUserId(int userId)
        {
            CartDto cart = new CartDto();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Cart WHERE UserId = @UserId; ";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserId", userId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CartDto
                {
                    IdCart = int.Parse(reader["IdCart"].ToString()),
                    UserId = int.Parse(reader["UserId"].ToString()),
                    ProductId = int.Parse(reader["ProductId"].ToString()),
                    Quantity = int.Parse(reader["Quantity"].ToString())
                };
            }
        }

        public void Delete(int userId, int productId)
        {
            string query = " DELETE FROM Cart WHERE UserId = @UserId AND ProductId = @ProductId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ProductId", productId);
            command.Parameters.AddWithValue("UserId", userId);
            command.ExecuteNonQuery();
        }

    }
}
