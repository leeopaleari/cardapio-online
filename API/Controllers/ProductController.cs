using AutoMapper;
using CardapioOnline.Application.DTOs;
using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace CardapioOnline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadProductDto>>> GetAll()
    {
        try
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var productExists = await _productService.GetByIdAsync(productDto.Code);

            if (productExists is not null && productExists.Code == productDto.Code)
            {
                return BadRequest(new { message = "Já existe um produto com o código informado" });
            }

            var product = await _productService.Create(productDto);

            return CreatedAtAction(nameof(GetById), new { Id = product.Code }, product);
        }
        catch (Exception error)
        {
            Console.WriteLine($" >>>>>  {error}");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id);


            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}