using AutoMapper;
using CardapioOnline.API.Data;
using CardapioOnline.API.Interfaces;
using CardapioOnline.API.Models;
using CardapioOnline.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductController(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            var response = _mapper.Map<List<ReadProductDto>>(products);

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);


            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var productExists = await _productRepository.GetByIdAsync(productDto.Code);

            if (productExists is not null && productExists.Code == productDto.Code)
            {
                return BadRequest(new { message = "Já existe um produto com o código informado" });
            }

            Product product = _mapper.Map<Product>(productDto);

            _productRepository.Create(product);

            return CreatedAtAction(nameof(GetById), new { Id = product.Code }, product);
        }
        catch (Exception error)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Product>> Update([FromRoute] int id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null || product.Code != id)
            {
                return NotFound();
            }

            Product productToUpdate = _mapper.Map<Product>(productDto);

            _productRepository.Update(productToUpdate);

            return Ok(productDto);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null || product.Code != id)
            {
                return NotFound();
            }

            _productRepository.Delete(product);

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}