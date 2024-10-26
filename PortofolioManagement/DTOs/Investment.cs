using PortofolioManagement.DbModels;

namespace PortofolioManagement.DTOs
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal ROI { get; set; }
        public int PortofolioId { get; set; }
        public int CryptoCurrencyId { get; set; }
        public virtual Cryptocurrency Cryptocurrency { get; set; }
    }
}
