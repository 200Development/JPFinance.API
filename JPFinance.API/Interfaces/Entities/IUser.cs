namespace JPFinance.API.Interfaces.Entities;

public interface IUser
{
    string? ClientUserId { get; set; }
    string? PhoneNumber { get; set; }
}