using Microsoft.AspNetCore.Mvc;
using TodoNet.DTOs;
using TodoNet.Exceptions;
using TodoNet.Models;
using TodoNet.Services;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService _todoService;
    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }


    [HttpGet("")]
    public async Task<List<Todo>> getAll()
    {
        return await _todoService.GetAllAsync();
    }

    [HttpGet(":id")]
    public async Task<Todo> GetTodo(int id)
    {
        return await _todoService.GetAsync(id);
    }

    [HttpPost("")]
    public async Task<Todo> createTodo([FromBody] CreateTodoDto dto)
    {
        return await _todoService.CreateAsync(dto);
    }

    [HttpPut(":id")]
    public async Task<IActionResult> updateTodo(int id, [FromBody] CreateTodoDto dto)
    {
        return Ok(await _todoService.UpdateAsync(id, dto));
    }

    [HttpDelete(":id")]
    public async Task<StatusCodeResult> deleteTodo(int id)
    {
        await _todoService.DeleteAsync(id);
        return Ok();
    }
}

