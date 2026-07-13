using BatchnewB3.Model;

namespace BatchnewB3.Repo
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetMethod();
        Product GetbyId(int id);
                         //int num;
        void AddProuduct(Product product);

        void   UpdateProduct(Product product);

        void DeleteProduct(int id);







    }


}
