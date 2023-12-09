using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<Product> GetItem(int id);
        Task<IEnumerable<Product>> GetItemsByCategory(int id);
    }
}
