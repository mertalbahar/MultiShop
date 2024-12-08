using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.WebApi.Dtos.ProductDetailDtos;
using MultiShop.Catalog.WebApi.Entities;
using MultiShop.Catalog.WebApi.Settings;

namespace MultiShop.Catalog.WebApi.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductDetailService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        ProductDetail value = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
    {
        List<ProductDetail> values = await _productDetailCollection.Find(x => true).ToListAsync();
        List<Product> products = await _productCollection.Find(x => true).ToListAsync();

        var result = _mapper.Map<List<ResultProductDetailDto>>(values);

        foreach (var item in result)
        {
            var product = products.FirstOrDefault(x => x.Id.Equals(item.ProductId));

            if (product != null)
            {
                item.ProductName = product.Name;
            }
        }

        return result;
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id)
    {
        ProductDetail value = await _productDetailCollection.Find<ProductDetail>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductDetailDto>(value);
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string productId)
    {
        ProductDetail values = await _productDetailCollection.Find(x => x.ProductId.Equals(productId)).FirstOrDefaultAsync();
        Product product = await _productCollection.Find(x => x.Id.Equals(productId)).FirstOrDefaultAsync();

        var result = _mapper.Map<GetByIdProductDetailDto>(values);
        result.ProductName = product.Name;

        return result;
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        ProductDetail value = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateProductDetailDto.Id), value);
    }
}
