
using BatchnewB3.Model;
using Microsoft.Data.SqlClient;

namespace BatchnewB3.Repo
{
    public class ProductRepo : IProductRepo
    {
        private string _connectionString;
        public ProductRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<Product> GetMethod()
        {
            List<Product> product= new List<Product>();
            SqlConnection con = new SqlConnection(_connectionString);
            string query="select * from Product";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {

                Product prod = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    order_id = Convert.ToInt32(reader["order_id"]),
                    Location = reader["Location"].ToString(),
                    isavailable = Convert.ToBoolean(reader["isavailable"]),
                    Price = Convert.ToInt32(reader["Price"])

                };
                product.Add(prod);
            }

            return product;
        }
        public void AddProuduct(Product product)
        {
           
        }

        public void DeleteProduct(int id)
        {
          
        }

        public Product GetbyId(int id)
        {
            
        }

      

        public void UpdateProduct(Product product)
        {
           
        }
    }
}
