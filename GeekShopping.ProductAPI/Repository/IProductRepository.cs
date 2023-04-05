using GeekShopping.Web.Data.Dtos;

namespace GeekShopping.Web.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(long id);
        Task<ProductDto> Create(ProductDto dto);
        Task<ProductDto> Update(ProductDto dto);
        Task<bool> Delete(long id);
    }
}
