using EcomBlaze_Business.Repository.IRepository;
using EcomBlaze_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomBlaze_DataAccess;
using EcomBlaze_Models;
using EcomBlaze_DataAccess.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EcomBlaze_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            category.CreatedDate = DateTime.Now;

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null) 
            { 
                _dbContext.Remove(obj);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_dbContext.Categories);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var obj = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var obj = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryDTO.Id);
            if (obj != null)
            {
                obj.Name = categoryDTO.Name;
                _dbContext.Update(obj);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return categoryDTO;
        }
    }
}
