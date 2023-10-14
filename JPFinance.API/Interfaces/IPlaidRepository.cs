namespace JPFinance.API.Interfaces;

public interface IPlaidRepository
{
    Task<string> CreateLinkToken();
    Task<string?> ExchangePublicToken(string publicToken);
}