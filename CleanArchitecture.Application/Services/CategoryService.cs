using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categoriesEntity);
        }

        public async Task Remove(int id)
        {
            var categoriesEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoriesEntity);

        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categoriesEntity);
        }
    }
}