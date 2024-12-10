using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.WebApi.Entities;
using MultiShop.Catalog.WebApi.Settings;

namespace MultiShop.Catalog.WebApi.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(x => x.Name).Exclude("Id");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("Name").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(x => x.Name).Exclude("Id");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("Name").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument
                {
                    { "Price", new BsonDocument("$ne", BsonNull.Value) }
                }),
                new BsonDocument("$project", new BsonDocument
                {
                    { "Price", new BsonDocument("$convert", new BsonDocument
                        {
                            { "input", "$Price" },
                            { "to", "decimal" },
                            { "onError", 0 }
                        })
                    }
                }),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", BsonNull.Value },
                    { "avgPrice", new BsonDocument("$avg", "$Price") }
                })
            };

            var value = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            if (await value.MoveNextAsync())
            {
                var firstResult = value.Current.FirstOrDefault();
                if (firstResult != null && firstResult.TryGetValue("avgPrice", out var avgPrice) && avgPrice.IsNumeric)
                {
                    return avgPrice.ToDecimal();
                }
            }

            return 0m;

        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
