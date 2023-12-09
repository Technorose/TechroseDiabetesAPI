using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.NameTranslation;

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
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                .ReplaceService<INpgsqlNameTranslator, NpgsqlSnakeCaseNameTranslator>()
                .EnableSensitiveDataLogging();
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<NutritionModel> Nutritions { get; set; }
    }
}
