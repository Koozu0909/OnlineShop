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


        protected IOrderedEnumerable<IGrouping<int, ProductDTO>> GetGroupProductsByCategory()
        {
            return from product in Products
              group product by product.CategoryId into proByCatGroup
              orderby proByCatGroup.Key
              select proByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int , ProductDTO> groupedProductDTOs)  {
            return groupedProductDTOs.FirstOrDefault(pg => pg.CategoryId == groupedProductDTOs.Key).CategoryName;
        }
    }
}
