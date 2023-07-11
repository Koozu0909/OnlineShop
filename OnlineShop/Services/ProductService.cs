using OnlineShop.Models.DTO;
using OnlineShop.Services.Contracts;
using System.Net.Http.Json;

namespace OnlineShop.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductDTO> GetItem(int id)
        {
            try
            {
                var req = await this.httpClient.GetAsync($"api/Product/{id}");
                if (req.IsSuccessStatusCode)
                {
                    if(req.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDTO);
                    }
                    return await req.Content.ReadFromJsonAsync<ProductDTO>();
                }
                else
                {
                    var mess = await req.Content.ReadAsStringAsync();
                    throw new Exception(mess);
                }
            }
            catch (Exception)
            {
                // Log Exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetItems()
        {
            try
            {
                var req = await this.httpClient.GetAsync("api/Product");
                if (req.IsSuccessStatusCode)
                {
                    if (req.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDTO>();
                    }
                    #pragma warning disable CS8603 // Possible null reference return.
                    return await req.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
                    #pragma warning restore CS8603 // Possible null reference return.

                }
                else
                {
                    var mess = await req.Content.ReadAsStringAsync();
                    throw new Exception(mess);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
