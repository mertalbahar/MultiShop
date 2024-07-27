using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMongoCollection<Product> _productCollection;

    public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
        IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        Category value = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        List<Category> values = await _categoryCollection.Find(x => true).ToListAsync();

        foreach (var item in values)
        {
            item.Products = await _productCollection.Find(p => p.CategoryId.Equals(item.Id)).ToListAsync();
        }

        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
    {
        Category value = await _categoryCollection.Find<Category>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdCategoryDto>(value);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        Category value = _mapper.Map<Category>(updateCategoryDto);
        await _categoryCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateCategoryDto.Id), value);
    }
}
