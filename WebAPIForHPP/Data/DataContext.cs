using Microsoft.EntityFrameworkCore;
using WebAPIForHPP.Models;

namespace WebAPIForHPP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Motor> Motors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
