using System.Text.Json.Serialization;

namespace JPFinance.API.Models
{
    public class User
    {
        [JsonPropertyName("client_user_id")] 
        public string? ClientUserId { get; set; }
     
        [JsonPropertyName("phone_number")] 
        public string? PhoneNumber { get; set; }
    }
}