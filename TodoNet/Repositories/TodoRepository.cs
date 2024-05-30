using Microsoft.EntityFrameworkCore;
using TodoNet.Data;
using TodoNet.DTOs;
using TodoNet.Models;

namespace TodoNet.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly DataContext _dataContext;
        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Todo>> GetAllAsync()
        {
            return await _dataContext.Todos.ToListAsync();
        }

        public async Task<Todo?> GetAsync(int id)
        {
            return await _dataContext.Todos.FirstOrDefaultAsync(c=>c.Id.Equals(id));
        }


        public async Task<Todo> CreateAsync(CreateTodoDto dto)
        {
            Todo newTodo = new Todo() { Title = dto.title, Description = dto.description, State = dto.state };
            _dataContext.Todos.Add(newTodo);
            await _dataContext.SaveChangesAsync();
            return newTodo;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _dataContext.Remove(id);
                await _dataContext.SaveChangesAsync();
            }catch
            {
                // add log here;
                throw;
            }
        }


        public async Task<Todo?> UpdateAsync(int id, CreateTodoDto dto)
        {
            Todo? todo = await this.GetAsync(id);
            if (todo == null)
            {
                // update it to throw an bad request exception
                return null;
            }
            todo.Title = dto.title;
            todo.Description = dto.description;
            todo.State = dto.state;
            await _dataContext.SaveChangesAsync();
            return todo;
        }
    }
}
