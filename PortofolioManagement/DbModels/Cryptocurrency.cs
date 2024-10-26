namespace PortofolioManagement.DbModels
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CryptoPriceHistory> PriceHistories { get; set; }
    }
}
