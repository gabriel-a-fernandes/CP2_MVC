using CP2_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_MVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> PZ_Users { get; set; }
    }
}
