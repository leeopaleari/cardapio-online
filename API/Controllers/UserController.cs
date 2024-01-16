using CardapioOnline.Application.DTOs.ClientDTO;
using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetAll()
    {
        try
        {
            var clients = await _userService.GetAllAsync();

            return Ok(clients);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _userService.Create(userDto);

            return Ok("Usuário criado com sucesso");
            // return CreatedAtAction(nameof(GetById), new { Id = client.Id }, client);
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(string id)
    {
        try
        {
            var client = await _userService.GetByIdAsync(id);


            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}