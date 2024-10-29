using Product.Domain.Entities;

namespace Product.Application.Services;

public interface IProductItemServices
{
    Task<List<ProductItem>> GetAllProductItems();
    Task<ProductItem> GetProductItemById(int id);
    Task<ProductItem> CreateProductItem(ProductItem entity);
    Task<int> UpdateProductItem(int id, ProductItem entity);
    Task<int> DeleteProductItem(int id);
}
