using Jcf.Lab.LocalDB.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.LocalDB.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
                
        public DbSet<User> Users { get; set; }      
    }
}
