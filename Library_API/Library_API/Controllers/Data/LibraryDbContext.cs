using Library_API.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Controllers.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
