using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TodoNet.DTOs;
using TodoNet.Exceptions;
using TodoNet.Models;
using TodoNet.Repositories;

namespace TodoNet.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepo;
        public TodoService(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<Todo> CreateAsync(CreateTodoDto dto)
        {
            return await _todoRepo.CreateAsync(dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _todoRepo.DeleteAsync(id);
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _todoRepo.GetAllAsync();
        }

        public async Task<Todo> GetAsync(int id)
        {
            var todo = await _todoRepo.GetAsync(id);
            if(todo == null)
            {
                throw new NotFoundException("Todo not found");
            }
            return todo;
        }

        public async Task<Todo> UpdateAsync(int id, CreateTodoDto dto)
        {
            var todo = await _todoRepo.UpdateAsync(id, dto);
            if( todo == null)
            {
                throw new BadReqeustException("todo not exists");
            }
            return todo;
        }
    }
}

