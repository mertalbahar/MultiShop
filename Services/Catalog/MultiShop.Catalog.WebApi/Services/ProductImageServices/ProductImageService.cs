using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.WebApi.Dtos.ProductImageDtos;
using MultiShop.Catalog.WebApi.Entities;
using MultiShop.Catalog.WebApi.Settings;

namespace MultiShop.Catalog.WebApi.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        ProductImage value = _mapper.Map<ProductImage>(createProductImageDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
    {
        List<ProductImage> values = await _productImageCollection.Find(x => true).ToListAsync();
        List<Product> products = await _productCollection.Find(x => true).ToListAsync();

        var result = _mapper.Map<List<ResultProductImageDto>>(values);

        foreach (var item in result)
        {
            var product = products.FirstOrDefault(x => x.Id.Equals(item.ProductId));

            if (product != null)
            {
                item.ProductName = product.Name;
                item.ProductImageUrl = product.ImageUrl;
            }
        }

        return result;
    }

    public async Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id)
    {
        ProductImage value = await _productImageCollection.Find<ProductImage>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductImageDto>(value);
    }

    public async Task<GetByIdProductImageDto> GetProductImageByProductIdAsync(string productId)
    {
        ProductImage values = await _productImageCollection.Find(x => x.ProductId.Equals(productId)).FirstOrDefaultAsync();
        Product product = await _productCollection.Find(x => x.Id.Equals(productId)).FirstOrDefaultAsync();

        var result = _mapper.Map<GetByIdProductImageDto>(values);
        result.ProductName = product.Name;
        result.ProductImageUrl = product.ImageUrl;

        return result;
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        ProductImage value = _mapper.Map<ProductImage>(updateProductImageDto);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateProductImageDto.Id), value);
    }
}
