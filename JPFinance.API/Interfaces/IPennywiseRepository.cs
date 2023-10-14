namespace JPFinance.API.Interfaces
{
    public interface IPennywiseRepository
    {
        public Task<bool> SaveAccessToken(int userId, string institutionId, string institutionName, string accessToken);
    }
}
