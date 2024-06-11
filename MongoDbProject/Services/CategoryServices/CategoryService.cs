using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings) //ctor
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var value = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async  Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var values = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == categoryDto.CategoryId, values);
        }
    }
}
