using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Mappings
{
    public static class MappingDtos
    {
        public static IEnumerable<CategoryDto> ConvertCategoriesToDto(
            this IEnumerable<Category> categories)
        {
            return (from category in categories
                    select new CategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IconCss = category.IconCss,
                    }).ToList();
        }
        public static IEnumerable<ProductDto> ConvertProductsToDto(
            this IEnumerable<Product> products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CategoryId = product.CategoryId,
                        CategoryName = product.Category.Name,
                    }).ToList();
        }
        public static ProductDto ConvertProductToDto(
            this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
            };
        }
        public static IEnumerable<CartItemDto> ConvertCartItemsToDto(
            this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageUrl,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Quantity = cartItem.Quantity,
                        TotalPrice = product.Price * cartItem.Quantity,
                    }).ToList();
        }
        public static CartItemDto ConvertCartItemToDto(
            this CartItem cartItem, Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageUrl,
                Price = product.Price,
                CartId = cartItem.CartId,
                Quantity = cartItem.Quantity,
                TotalPrice = product.Price * cartItem.Quantity,
            };
        }
    }
}
