using Microsoft.AspNetCore.Components;
using OnlineShop.Models.DTO;
using OnlineShop.Services;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Pages
{
    public class ProductsBase:ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }


        public IEnumerable<ProductDTO> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }
    }
}
