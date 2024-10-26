namespace PortofolioManagement.DTOs
{
    public class Portfolio
    {
        public int Id { get; set; }
        public List<Investment> Investments { get; set; } = new();
        public decimal TotalInvestedAmount => Investments is not null && Investments.Any() ? Investments.Sum(c => c.InvestedAmount) : 0;

        public decimal TotalValueToday = 0;

        public decimal ROI
        {
            get
            {
                var totalInvested = TotalInvestedAmount;
                var totalValue = TotalValueToday;

                // Avoid division by zero
                if (totalInvested == 0) return 0;

                return (totalValue - totalInvested) / totalInvested;
            }
        }
    }
}
