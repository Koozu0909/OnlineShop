using Microsoft.AspNetCore.Components;
using OnlineShop.Models.DTO;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Pages
{
    public class ProductDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public ProductDTO Product { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id); 
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

    }
}
