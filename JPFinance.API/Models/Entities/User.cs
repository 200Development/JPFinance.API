using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Models.Entities;

public class User : IUser
{
    [JsonPropertyName("client_user_id")] 
    public string? ClientUserId { get; set; }
     
    [JsonPropertyName("phone_number")] 
    public string? PhoneNumber { get; set; }
}