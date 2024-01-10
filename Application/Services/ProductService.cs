using AutoMapper;
using CardapioOnline.Application.DTOs;
using CardapioOnline.Application.Interfaces;

namespace CardapioOnline.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<CreateProductDto> Create(CreateProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateProductDto> Update(UpdateProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateProductDto> Delete(UpdateProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task<IList<ReadProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ReadProductDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}