using TodoNet.DTOs;
using TodoNet.Models;

namespace TodoNet.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetAsync(int id);
        Task<Todo> CreateAsync(CreateTodoDto dto);
        Task<Todo> UpdateAsync(int id, CreateTodoDto dto);
        Task DeleteAsync(int id);
    }
}
