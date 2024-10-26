using Microsoft.EntityFrameworkCore;

namespace PortofolioManagement.DbModels
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<CryptoPriceHistory> CryptoPriceHistories { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
