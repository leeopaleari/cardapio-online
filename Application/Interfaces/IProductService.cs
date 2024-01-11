using CardapioOnline.Application.DTOs;

namespace CardapioOnline.Application.Interfaces;

public interface IProductService
{
    Task<CreateProductDto> Create(CreateProductDto product);
    Task<UpdateProductDto> Update(UpdateProductDto product);
    Task<UpdateProductDto> Delete(int id);
    Task<IList<ReadProductDto>> GetAllAsync();
    Task<ReadProductDto> GetByIdAsync(int id);
}