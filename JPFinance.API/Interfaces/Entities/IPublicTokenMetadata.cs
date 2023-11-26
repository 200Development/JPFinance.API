using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Entities;

public interface IPublicTokenMetadata
{
    string PublicToken { get; set; }
    Institution Institution { get; set; }
    List<Account> Accounts { get; set; }
    Account? Account { get; set; }
    string LinkSessionId { get; set; }
}