using AutoMapper;
using CardapioOnline.Application.DTOs;
using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;

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

    public async Task<CreateProductDto> Create(CreateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var createdProduct = await _repository.Create(product);

        return _mapper.Map<CreateProductDto>(createdProduct);
    }

    public async Task<UpdateProductDto> Update(UpdateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var updatedProduct = await _repository.Update(product);

        return _mapper.Map<UpdateProductDto>(updatedProduct);
    }

    public async Task<UpdateProductDto> Delete(int id)
    {
        var deletedProduct = await _repository.Delete(id);

        return _mapper.Map<UpdateProductDto>(deletedProduct);
    }

    public async Task<IList<ReadProductDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();

        return _mapper.Map<IList<ReadProductDto>>(products);
    }

    public async Task<ReadProductDto> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        return _mapper.Map<ReadProductDto>(product);
    }
}