using PortofolioManagement.DbModels;

namespace PortofolioManagement.Services
{
    public class PriceSeederService
    {
        private readonly ApplicationDbContext _context;
        private readonly HistoricalPriceFetcherService _priceFetcher;

        public PriceSeederService(ApplicationDbContext context, HistoricalPriceFetcherService priceFetcher)
        {
            _context = context;
            _priceFetcher = priceFetcher;
        }

        public async Task SeedPricesAsync()
        {
            var fetcher = new HistoricalPriceFetcherService();
            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = DateTime.Now;

            var cryptocurrencies = new List<string> { "BTC", "ETH", "LTC", "SOL", "XRP" };

            foreach (var c in cryptocurrencies)
            {
                if (!_context.Cryptocurrencies.Any(p => p.Name.Equals(c)))
                {
                    var crypto = new Cryptocurrency()
                    {
                        Name = c,
                        PriceHistories = []
                    };

                    for (var date = startDate; date <= endDate; date = date.AddMonths(1))
                    {
                        decimal? price = await fetcher.GetPriceForDateAsync(date, c);

                        if (price.HasValue)
                        {

                            var priceEntry = new CryptoPriceHistory
                            {
                                PriceDate = date,
                                Price = price.Value
                            };

                            crypto.PriceHistories.Add(priceEntry);
                        }
                    }

                    _context.Cryptocurrencies.Add(crypto);
                    await _context.SaveChangesAsync();
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
