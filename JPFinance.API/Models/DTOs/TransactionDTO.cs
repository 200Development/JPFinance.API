using JPFinance.API.Interfaces.DTOs;

namespace JPFinance.API.Models.DTOs;

public class TransactionDTO : ITransactionDTO
{
    public string? AccountId { get; set; } = string.Empty;
    public double Amount { get; set; }

    public string? IsoCurrencyCode { get; set; }

    public string Date { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? MerchantName { get; set; }

    public string? OriginalDescription { get; set; }

    public string? Payee { get; set; }

    public string? Payer { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PendingTransactionId { get; set; }

    public string TransactionId { get; set; } = string.Empty;

    public string? LogoUrl { get; set; }

    public string? Website { get; set; }

    public string? AuthorizedDateTime { get; set; }
}