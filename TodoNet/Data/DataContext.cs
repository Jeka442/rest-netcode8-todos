using Microsoft.EntityFrameworkCore;
using TodoNet.Models;

namespace TodoNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { 
         
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
