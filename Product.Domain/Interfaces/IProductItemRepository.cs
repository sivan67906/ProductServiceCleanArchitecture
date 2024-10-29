using Product.Domain.Entities;

namespace Product.Domain.Interfaces;

public interface IProductItemRepository
{
    Task<List<ProductItem>> GetAllAsync();
    Task<ProductItem> GetByIdAsync(int id);
    Task<ProductItem> CreateAsync(ProductItem entity);
    Task<int> UpdateAsync(int id, ProductItem entity);
    Task<int> DeleteAsync(int id);
}
