﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.WebApi.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.WebApi.Entities;
using MultiShop.Catalog.WebApi.Settings;

namespace MultiShop.Catalog.WebApi.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

        public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            FeatureSlider value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            List<FeatureSlider> values = await _featureSliderCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
        {
            FeatureSlider value = await _featureSliderCollection.Find<FeatureSlider>(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            FeatureSlider value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id.Equals(updateFeatureSliderDto.Id), value);
        }
    }
}
