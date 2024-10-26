using PortofolioManagement.DbModels;

namespace PortofolioManagement.DTOs
{
    public class InvestmentInput
    {
        private int _selectedCurrencyId;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public int SelectedCurrencyId
        {
            get => _selectedCurrencyId;
            set
            {
                _selectedCurrencyId = value;
                UpdateSelectedCurrency();
            }
        }
        public Cryptocurrency SelectedCurrency { get; set; } = new();
        public decimal InvestmentAmount { get; set; } = 0;
        public List<Cryptocurrency> AvailableCurrencies { get; set; } = new();

        private void UpdateSelectedCurrency()
        {
            SelectedCurrency = AvailableCurrencies?.FirstOrDefault(c => c.Id == _selectedCurrencyId);
        }
    }
}
