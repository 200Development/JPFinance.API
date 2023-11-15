using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Entities;

public interface IPersonalFinanceCategory
{
    string Primary { get; set; }
    string Detailed { get; set; }
    string ConfidenceLevel { get; set; }  
}