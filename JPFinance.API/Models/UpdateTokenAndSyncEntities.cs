using JPFinance.API.Models.DTOs;

/*******************************************************************

 SQL Stored Procedure this model is written for:
 Pennywise.dbo.usp_UpdateTokenAndSyncEntities

*******************************************************************/

namespace JPFinance.API.Models
{
    public class UpdateTokenAndSyncEntities
    {
        public string UserId { get; set; }
      
        public string AccessToken { get; set; } = string.Empty;
    
        public Institution Institution { get; set; } = new();
   
        public AccountDto[] Accounts { get; set; } = Array.Empty<AccountDto>();
    }
}