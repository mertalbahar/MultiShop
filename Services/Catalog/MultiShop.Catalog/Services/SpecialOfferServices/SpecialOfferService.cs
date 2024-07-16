using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public SpecialOfferService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            SpecialOffer value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            List<SpecialOffer> values = await _specialOfferCollection.Find(so => true).ToListAsync();

            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            SpecialOffer value = await _specialOfferCollection.Find<SpecialOffer>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateSpecialOfferDto.Id), value);
        }
    }
}
