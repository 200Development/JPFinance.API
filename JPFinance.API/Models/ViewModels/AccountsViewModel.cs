namespace JPFinance.API.Models.ViewModels
{
    public class AccountsViewModel
    {
       public string Name { get; set; }
       public string Type { get; set; }
       public string Subtype { get; set; }
       public decimal CurrentBalance { get; set; }
       public decimal AvailableBalance { get; set; }
       public decimal Limit { get; set; }
       public string IsoCurrencyCode { get; set; }
    }
}
