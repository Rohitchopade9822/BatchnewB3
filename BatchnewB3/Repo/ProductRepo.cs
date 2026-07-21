
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
        public Product GetbyId(int id)
        {
            Product prod = null;
            SqlConnection con = new SqlConnection(_connectionString);
            string qury ="select * from Product where Id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(qury, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                prod = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    order_id = Convert.ToInt32(reader["order_id"]),
                    Location = reader["Location"].ToString(),
                    isavailable = Convert.ToBoolean(reader["isavailable"]),
                    Price = Convert.ToInt32(reader["Price"])
                };
            }
            return prod;
        }

        public void AddProuduct(Product product)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "insert into Product(Id,Name,order_id,Location,isavailable,Price)" +
                " values(@Name,@order_id,@Location,@isavailable,@Price)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@order_id", product.order_id);
            cmd.Parameters.AddWithValue("@Location", product.Location);
            cmd.Parameters.AddWithValue("@isavailable", product.isavailable);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateProduct(Product product)
        {
            SqlConnection con=new SqlConnection(_connectionString);

            string query = "update Product set Name=@Name,order_id=@order_id,Location=@Location," +
                "isavailable=@isavailable,Price=@Price where Id=@Id";
            con.Open(); 
            SqlCommand cmd=new SqlCommand(query,con);

            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@order_id", product.order_id);
            cmd.Parameters.AddWithValue("@Location", product.Location);
            cmd.Parameters.AddWithValue("@isavailable", product.isavailable);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.ExecuteNonQuery();
        }
      

        public void DeleteProduct(int  Id)
        {
          SqlConnection con=new SqlConnection(_connectionString);
            string query = "delete  from Product where id=@Id";
            con.Open();
            SqlCommand  cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.ExecuteNonQuery();
            con.Close();    
        }

       
      

      
    }
}
// addscope , addsingleton, addtransient    