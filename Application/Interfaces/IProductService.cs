using CardapioOnline.Application.DTOs;

namespace CardapioOnline.Application.Interfaces;

public interface IProductService
{
    Task<CreateProductDto> Create(CreateProductDto product);
    Task<UpdateProductDto> Update(UpdateProductDto product);
    Task<UpdateProductDto> Delete(UpdateProductDto product);
    Task<IList<ReadProductDto>> GetAllAsync();
    Task<ReadProductDto> GetByIdAsync(int id);
}