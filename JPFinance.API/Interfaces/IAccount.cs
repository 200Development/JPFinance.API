﻿using JPFinance.API.Models;

namespace JPFinance.API.Interfaces;

public interface IAccount
{
    string AccountId { get; set; }
    Balances Balances { get; set; }
    string Name { get; set; }
    string Type { get; set; }
    string Subtype { get; set; }
}