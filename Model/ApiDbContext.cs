using Microsoft.EntityFrameworkCore;

namespace TechroseDemo
{
    public class ApiDbContext : DbContext
    {
        private readonly IConfiguration Configuration;
        
        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<MealModel> Meals { get; set; }

        public DbSet<NutritionModel> Nutritions { get; set; }

        public DbSet<UserNutritionModel> UserNutritions { get; set; }
    }
}
