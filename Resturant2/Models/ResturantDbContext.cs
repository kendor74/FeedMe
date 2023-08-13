using Microsoft.EntityFrameworkCore;

namespace Resturant2.Models
{
    public class ResturantDbContext:DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public ResturantDbContext(IConfiguration confergration)
        //{
        //    Configuration = confergration;
        //}

        public ResturantDbContext(DbContextOptions<ResturantDbContext> option)
            :base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=aspnet-Resturant;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserMessages> UserMessages { get; set; }
    }
}
