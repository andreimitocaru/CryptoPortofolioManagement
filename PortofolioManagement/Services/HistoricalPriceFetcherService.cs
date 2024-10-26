using Newtonsoft.Json.Linq;
using RestSharp;

namespace PortofolioManagement.Services
{
    public class HistoricalPriceFetcherService
    {
        public async Task<decimal?> GetPriceForDateAsync(DateTime date, string cryptocurrency)
        {
            try
            {
                string formattedDate = date.ToString("dd-MM-yyyy");

                var options = new RestClientOptions();
                switch (cryptocurrency)
                {
                    case "BTC":
                        options.BaseUrl = new Uri($"https://api.coingecko.com/api/v3/coins/bitcoin/history?date={formattedDate}&localization=false");
                        break;
                    case "ETH":
                        options.BaseUrl = new Uri($"https://api.coingecko.com/api/v3/coins/ethereum/history?date={formattedDate}&localization=false");
                        break;

                    case "LTC":
                        options.BaseUrl = new Uri($"https://api.coingecko.com/api/v3/coins/litecoin/history?date={formattedDate}&localization=false");
                        break;

                    case "SOL":
                        options.BaseUrl = new Uri($"https://api.coingecko.com/api/v3/coins/solana/history?date={formattedDate}&localization=false");
                        break;

                    case "XRP":
                        options.BaseUrl = new Uri($"https://api.coingecko.com/api/v3/coins/ripple/history?date={formattedDate}&localization=false");
                        break;

                    default:
                        throw new ArgumentException($"Unsupported cryptocurrency: {cryptocurrency}");
                }

                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("x_cg_demo_api_key", "CG-kjMUrRsW16kQVQzPb9WurZ9v");

                var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var price = JObject.Parse(response.Content)?["market_data"]?["current_price"]?["eur"]?.Value<decimal>();
                    return price;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
