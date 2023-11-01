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
using Product = EcomBlaze_DataAccess.Product;

namespace EcomBlaze_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO ProductDTO)
        {
            var Product = _mapper.Map<ProductDTO, Product>(ProductDTO);

            _dbContext.Products.Add(Product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(Product);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null) 
            { 
                _dbContext.Remove(obj);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_dbContext.Products
                .Include(p => p.Category).Include(p => p.ProductPrices));
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var obj = await _dbContext.Products.Include(p => p.Category).Include(p => p.ProductPrices)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<ProductDTO> Update(ProductDTO ProductDTO)
        {
            var obj = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == ProductDTO.Id);
            if (obj != null)
            {
                obj.Name = ProductDTO.Name;
                obj.Description = ProductDTO.Description;
                obj.ImageUrl = ProductDTO.ImageUrl;
                obj.CategoryId = ProductDTO.CategoryId;
                obj.Color = ProductDTO.Color;
                obj.ShopFavorites = ProductDTO.ShopFavorites;
                obj.CustomerFavorites = ProductDTO.CustomerFavorites;
                _dbContext.Update(obj);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return ProductDTO;
        }
    }
}
