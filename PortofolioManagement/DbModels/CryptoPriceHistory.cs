namespace PortofolioManagement.DbModels
{
    public class CryptoPriceHistory
    {
        public int Id { get; set; }
        public DateTime PriceDate { get; set; }
        public decimal Price { get; set; }
        public int CryptocurrencyId { get; set; }
    }
}
