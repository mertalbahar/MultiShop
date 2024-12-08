using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.WebApi.Dtos.ProductDtos;
using MultiShop.Catalog.WebApi.Entities;
using MultiShop.Catalog.WebApi.Settings;
using System.Linq.Expressions;

namespace MultiShop.Catalog.WebApi.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;

    public ProductService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        Product value = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        List<Product> values = await _productCollection.Find(x => true).ToListAsync();
        List<Category> categories = await _categoryCollection.Find(x => true).ToListAsync();
        var result = _mapper.Map<List<ResultProductDto>>(values);

        foreach (var item in result)
        {
            var category = categories.FirstOrDefault(x => x.Id.Equals(item.CategoryId));

            if (category != null)
            {
                item.CategoryName = category.Name;
            }
        }

        return result;
    }

    public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
    {
        Product value = await _productCollection.Find<Product>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductDto>(value);
    }

    public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
    {
        List<Product> values = await _productCollection.Find(x => x.CategoryId.Equals(categoryId)).ToListAsync();
        Category category = await _categoryCollection.Find(x => x.Id.Equals(categoryId)).FirstOrDefaultAsync();
        var result = _mapper.Map<List<ResultProductDto>>(values);

        foreach (var item in result)
        {
            if (category != null)
            {
                item.CategoryName = category.Name;
            }
        }

        return result;
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        Product value = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateProductDto.Id), value);
    }
}
