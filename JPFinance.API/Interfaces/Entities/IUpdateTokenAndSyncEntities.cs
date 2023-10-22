using JPFinance.API.Models.DTOs;
using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Entities;

public interface IUpdateTokenAndSyncEntities
{
    int UserId { get; set; }
    string AccessToken { get; set; }
    Institution Institution { get; set; }
    List<AccountDto> Accounts { get; set; }
}