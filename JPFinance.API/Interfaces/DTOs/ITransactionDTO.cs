namespace JPFinance.API.Interfaces.DTOs;

public interface ITransactionDTO
{
    string AccountId { get; set; }
    double Amount { get; set; }
    string? IsoCurrencyCode { get; set; }
    string Date { get; set; }
    string Name { get; set; }
    string? MerchantName { get; set; }
    string? OriginalDescription { get; set; }
    string? Payee { get; set; }
    string? Payer { get; set; }
    string? PaymentMethod { get; set; }
    string? PendingTransactionId { get; set; }
    string TransactionId { get; set; }
    string? LogoUrl { get; set; }
    string? Website { get; set; }
    string? AuthorizedDateTime { get; set; }
}