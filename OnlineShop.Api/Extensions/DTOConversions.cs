using OnlineShop.Api.Entities;
using OnlineShop.Models.DTO;

namespace OnlineShop.Api.Extensions
{
    public static class DTOConversions
    {
        public static IEnumerable<ProductDTO> ConvertToDTO(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name,
                    }).ToList();
        }

        public static ProductDTO ConvertToDTO(this Product products, ProductCategory productCategories)
        {
            return new ProductDTO
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                ImageURL = products.ImageURL,
                Price = products.Price,
                Qty = products.Qty,
                CategoryId = products.CategoryId,
                CategoryName = productCategories.Name,
            };
        }
    }
}
