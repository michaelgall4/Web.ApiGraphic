using Web.Api.Models;
using System.Data.SqlClient;

namespace Web.Api.SQL
{
    public class ProductDataProvider : IProductDataProvider
    {
        private string _connectionString;
        public ProductDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Product GetProductById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Product WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                throw new Exception("No product found");

            return new Product()
            {
                Id = int.Parse(reader["ID"].ToString()),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Quantity = int.Parse(reader["Quantity"].ToString()),
                Price = decimal.Parse(reader["Price"].ToString())
            };
        }
    }
}
