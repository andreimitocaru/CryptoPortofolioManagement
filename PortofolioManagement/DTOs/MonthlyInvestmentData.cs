namespace PortofolioManagement.DTOs
{
    public class MonthlyInvestmentData
    {
        public int InvestmentId { get; set; }
        public DateTime Date { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal ROI { get; set; }
    }

}
