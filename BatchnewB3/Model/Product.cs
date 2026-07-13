using Microsoft.AspNetCore.Server.HttpSys;

namespace BatchnewB3.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int order_id { get; set; } 
        public string Location { get; set; }
        public bool isavailable { get; set; }
        public int  Price { get; set; }
    }
}
