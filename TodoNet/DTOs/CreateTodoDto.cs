using TodoNet.Models;

namespace TodoNet.DTOs
{
    public record CreateTodoDto(String title, String description, TodoState state)
    {
    }
}
