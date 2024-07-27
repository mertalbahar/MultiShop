using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.DiscountOfferServices
{
    public class DiscountOfferService : IDiscountOfferService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<DiscountOffer> _discountOfferCollection;

        public DiscountOfferService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountOfferCollection = database.GetCollection<DiscountOffer>(_databaseSettings.DiscountOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
        {
            DiscountOffer value = _mapper.Map<DiscountOffer>(createDiscountOfferDto);
            await _discountOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountOfferAsync(string id)
        {
            await _discountOfferCollection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOffersAsync()
        {
            List<DiscountOffer> values = await _discountOfferCollection.Find(so => true).ToListAsync();

            return _mapper.Map<List<ResultDiscountOfferDto>>(values);
        }

        public async Task<GetByIdDiscountOfferDto> GetDiscountOfferByIdAsync(string id)
        {
            DiscountOffer value = await _discountOfferCollection.Find<DiscountOffer>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdDiscountOfferDto>(value);
        }

        public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            var value = _mapper.Map<DiscountOffer>(updateDiscountOfferDto);
            await _discountOfferCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateDiscountOfferDto.Id), value);
        }
    }
}
