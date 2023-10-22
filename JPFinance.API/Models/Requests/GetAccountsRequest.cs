using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Requests;

namespace JPFinance.API.Models.Requests
{
    public class GetAccountsRequest : IGetAccountsRequest
    {
        public GetAccountsRequest(string accessToken)
        {
            AccessToken = accessToken;
        }

        [Required]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
