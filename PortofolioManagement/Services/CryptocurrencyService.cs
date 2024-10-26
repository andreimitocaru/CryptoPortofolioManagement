using Microsoft.EntityFrameworkCore;
using PortofolioManagement.DbModels;

namespace PortofolioManagement.Services
{
    public class CryptocurrencyService
    {
        private readonly ApplicationDbContext _context;

        public CryptocurrencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cryptocurrency>> GetAvailableCryptocurrenciesAsync()
        {
            var cryptocurrencyList = await _context.Cryptocurrencies.ToListAsync();

            return cryptocurrencyList;
        }
    }
}
