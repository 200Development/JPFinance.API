using JPFinance.API.Interfaces.ViewModels;

namespace JPFinance.API.Models.ViewModels;

public class AccountsViewModel : IAccountsViewModel
{
<<<<<<< HEAD
    public string AccountId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Subtype { get; set; } = string.Empty;
    public decimal CurrentBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal Limit { get; set; }
    public string IsoCurrencyCode { get; set; } = string.Empty;
}
=======
    public class AccountViewModel
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
>>>>>>> trunk
