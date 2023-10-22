﻿using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Entities;

public interface IModified
{
    string Id { get; set; }
    double Amount { get; set; }
    string? IsoCurrencyCode { get; set; }
    string? CategoryId { get; set; }
    string Date { get; set; }
    Location Location { get; set; }
    string TransactionId { get; set; }
}