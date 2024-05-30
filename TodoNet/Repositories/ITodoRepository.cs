using TodoNet.DTOs;
using TodoNet.Models;

namespace TodoNet.Repositories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetAsync(int id);
        Task<Todo> CreateAsync(CreateTodoDto dto);
        Task<Todo?> UpdateAsync(int id, CreateTodoDto dto);
        Task DeleteAsync(int id);

    }
}
