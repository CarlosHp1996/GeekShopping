using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.Web.Data.Dtos;
using GeekShopping.Web.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<ProductDto> Create(ProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Update(ProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p =>p.Id == id)
                    .FirstOrDefaultAsync() ?? new Product();
                if (product.Id <= 0)
                    return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
        }             
    }
}
