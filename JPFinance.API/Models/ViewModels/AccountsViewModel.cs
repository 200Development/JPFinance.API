using JPFinance.API.Interfaces.ViewModels;

namespace JPFinance.API.Models.ViewModels;

public class AccountsViewModel : IAccountsViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Subtype { get; set; } = string.Empty;
    public decimal CurrentBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal Limit { get; set; }
    public string IsoCurrencyCode { get; set; } = string.Empty;
}