using System.Collections.Generic;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public interface IProductService
    { 
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task SaveProduct(Product product);
        Task DeleteProduct(Product product);      
    }
}
