namespace JPFinance.API.Interfaces.Responses;

public interface IGetAccessTokenAndLatestCursorResponse
{
    string AccessToken { get; set; }
    string? NextCursor { get; set; }
}