﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productDetailCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.ConnectionString);
            _productDetailCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }


        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _productDetailCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productDetailCollection.Find<ProductImage>(x => true).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }
    }
}
