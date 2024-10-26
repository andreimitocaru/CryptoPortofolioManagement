using Microsoft.EntityFrameworkCore;
using PortofolioManagement.DbModels;

namespace PortofolioManagement.Services
{
    public class PriceService
    {
        private readonly ApplicationDbContext _context;

        public PriceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CryptoPriceHistory>> GetPriceHistoryAsync(string cryptocurrency, DateTime startDate)
        {
            var priceHistoryList = await _context.Cryptocurrencies
                .Where(x => x.Name == cryptocurrency)
                .SelectMany(x => x.PriceHistories)
                .Where(ph => ph.PriceDate >= startDate)
                .ToListAsync();

            return priceHistoryList;
        }
    }
}
