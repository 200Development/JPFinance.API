/*******************************************************************
// 
// Link to Plaid documentation explaining the structure of this model:
// https://plaid.com/docs/api/accounts/#account-type-schema
// 
// *******************************************************************/

namespace JPFinance.API.Models.Enums;

public enum AccountType
{
    Depository,
    Credit,
    Loan,
    Investment
}