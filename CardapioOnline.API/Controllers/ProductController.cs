using AutoMapper;
using CardapioOnline.API.Data;
using CardapioOnline.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private IMapper _mapper;
    private static AppDbContext _context;

    public ProductController(IMapper mapper, AppDbContext ctx)
    {
        _mapper = mapper;
        _context = ctx;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var products = _context.Product.ToList();
            var response = _mapper.Map<List<ReadProductDto>>(products);

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var product = _context.Product.FirstOrDefault(p => p.Code == id);

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
    public IActionResult Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (_context.Product.Any(p => p.Code == productDto.Code))
            {
                return BadRequest(new { message = "Já existe um produto com o código informado" });
            }

            Product product = _mapper.Map<Product>(productDto);

            _context.Product.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id = product.Code }, product);
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível cadastrar o produto. Detalhes: {error.Message}" });
        }
    }
}