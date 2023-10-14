using Dapper;
using System.Data;
using System.Data.SqlClient;
using JPFinance.API.Interfaces;

namespace JPFinance.API.Repositories
{
    public class PennywiseRepository : IPennywiseRepository
    {
        private readonly string _connectionString;
        public PennywiseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> SaveAccessToken(int userId, string institutionId, string institutionName, string accessToken)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@InstitutionId", institutionId);
                parameters.Add("@InstitutionName", institutionName);
                parameters.Add("@AccessToken", accessToken);

                var rows = await connection.ExecuteAsync("StoreAccessToken", parameters, commandType: CommandType.StoredProcedure);
                if(rows > 0) { return true; }
            }

            return false;
        }
    }
}
