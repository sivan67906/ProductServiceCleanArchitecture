using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using Product.Persistence.Data;
using System;

namespace Product.Persistence.Repositories;

public class ProductItemRepository : IProductItemRepository
{

    private readonly ProductServiceDbContext _productServiceDbContext;

    public ProductItemRepository(ProductServiceDbContext productServiceDbContext)
    {
        _productServiceDbContext = productServiceDbContext;
    }

    public async Task<ProductItem> CreateAsync(ProductItem prodcutItem)
    {
        var result = _productServiceDbContext.ProductItems.Add(prodcutItem);
        await _productServiceDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
        //var result = _productServiceDbContext.ProductItems.Where(emp => emp.Id == id).FirstOrDefault();
        //_productServiceDbContext.ProductItems.Remove(result);
        //await _productServiceDbContext.SaveChangesAsync();
        //return result.Id;

        return await _productServiceDbContext.ProductItems.Where(b => b.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<ProductItem>> GetAllAsync()
    {
        List<ProductItem> result = _productServiceDbContext.ProductItems.ToList();
        return result;
    }

    public async Task<ProductItem> GetByIdAsync(int id)
    {
        var result = _productServiceDbContext.ProductItems.Where(p => p.Id == id).FirstOrDefault();
        return result;
    }

    public async Task<int> UpdateAsync(int id, ProductItem entity)
    {
        //var result = _productServiceDbContext.ProductItems.Update(entity);
        //await _productServiceDbContext.SaveChangesAsync();
        //return result.Entity.Id;

        return await _productServiceDbContext.ProductItems
        .Where(x => x.Id == id)
        .ExecuteUpdateAsync(b => b
        .SetProperty(b => b.Id, entity.Id)
        .SetProperty(b => b.Name, entity.Name)
        .SetProperty(b => b.Price, entity.Price));

    }
}
