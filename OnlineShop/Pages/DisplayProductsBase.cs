using Microsoft.AspNetCore.Components;
using OnlineShop.Models.DTO;

namespace OnlineShop.Pages
{
    public class DisplayProductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
