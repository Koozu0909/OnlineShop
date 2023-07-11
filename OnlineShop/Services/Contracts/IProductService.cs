using OnlineShop.Models.DTO;

namespace OnlineShop.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetItems();
        Task<ProductDTO> GetItem(int id);
    }
}
