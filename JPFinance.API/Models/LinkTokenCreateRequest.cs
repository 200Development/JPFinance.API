﻿using System.Text.Json.Serialization;

namespace JPFinance.API.Models;

public class LinkTokenCreateRequest
{
    [JsonPropertyName("user")]
    public User? User { get; set; }
    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }
    [JsonPropertyName("products")]
    public List<string>? Products { get; set; }
    [JsonPropertyName("country_codes")]
    public List<string>? CountryCodes { get; set; }
    [JsonPropertyName("language")]
    public string? Language { get; set; }
    [JsonPropertyName("required_if_supported_products")]
    public List<string>? RequiredIfSupportedProducts { get; set; }
    [JsonPropertyName("webhook")]
    public string? Webhook { get; set; }
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }
}