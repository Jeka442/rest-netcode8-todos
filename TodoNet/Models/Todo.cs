
namespace TodoNet.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required TodoState State { get; set; }
    }
}
