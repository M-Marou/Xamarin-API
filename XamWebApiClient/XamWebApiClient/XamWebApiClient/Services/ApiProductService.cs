using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class ApiProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync("Products");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Product>>(responseAsString);

        }

        public async Task<Product> GetProduct(int id)
        {
            var response = await _httpClient.GetAsync($"Products/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<Product>(responseAsString);
        }

        public async Task AddProduct(Product product)
        {
            var response = await _httpClient.PostAsync("Products", new StringContent(System.Text.Json.JsonSerializer.Serialize(product), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(Product product)
        {
            var response = await _httpClient.DeleteAsync($"Products/{product.Id}");

            response.EnsureSuccessStatusCode();
        }      

        public async Task SaveProduct(Product product)
        {
            var response = await _httpClient.PutAsync($"Productst?id={product.Id}",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(product), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
