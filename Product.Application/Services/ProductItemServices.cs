using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Application.Services;

public class ProductItemServices : IProductItemServices
{
    private readonly IProductItemRepository _productItemRepository;

    public ProductItemServices(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }

    public Task<ProductItem> CreateProductItem(ProductItem entity)
    {
        return _productItemRepository.CreateAsync(entity);
    }

    public Task<int> DeleteProductItem(int id)
    {
        return _productItemRepository.DeleteAsync(id);
    }

    public Task<List<ProductItem>> GetAllProductItems()
    {
        return _productItemRepository.GetAllAsync();
    }

    public Task<ProductItem> GetProductItemById(int id)
    {
        return _productItemRepository.GetByIdAsync(id);
    }

    public Task<int> UpdateProductItem(int id, ProductItem entity)
    {
        return _productItemRepository.UpdateAsync(id, entity);
    }
}
