using Microsoft.EntityFrameworkCore;

namespace TechroseDemo
{
    public class ApiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
