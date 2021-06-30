using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamWebApiClient.Models;


namespace XamWebApiClient.Services
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Product> _product = new List<Product>();
        public InMemoryProductService()
        {
            _product.Add(new Product { Id = 1, Title = "Clean code", Prix = 12, Description = "A book about good code" });
            _product.Add(new Product { Id = 2, Title = "The pragmatic programmer", Prix = 20, Description = "All about pragmatism" });
            _product.Add(new Product { Id = 3, Title = "Refactoring", Prix = 30, Description = "Working with legacy code" });
        }

        public Task AddProduct(Product product)
        {
            product.Id = ++_product.Last().Id;
            _product.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(Product product)
        {
            _product.Remove(product);
            return Task.CompletedTask;
        }

        public Task<Product> GetProduct(int id)
        {
            var product = _product.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return Task.FromResult(_product.AsEnumerable());
        }

        public Task SaveProduct(Product product)
        {
            _product[_product.FindIndex(b => b.Id == product.Id)] = product;
            return Task.CompletedTask;
        }
    }
}
