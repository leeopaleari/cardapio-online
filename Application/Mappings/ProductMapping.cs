using AutoMapper;
using CardapioOnline.Application.DTOs;
using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ReadProductDto>();
        CreateMap<Product, UpdateProductDto>();
    }
}