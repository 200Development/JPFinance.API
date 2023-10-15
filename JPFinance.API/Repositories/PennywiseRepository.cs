using System.Data;
using System.Data.SqlClient;
using JPFinance.API.Interfaces;
using JPFinance.API.Models;
using Newtonsoft.Json;

namespace JPFinance.API.Repositories
{
    public class PennywiseRepository : IPennywiseRepository
    {
        private readonly string _connectionString;
        public PennywiseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        

        public async Task<bool> UpdateTokenAndSyncEntities(UpdateTokenAndSyncEntities dto)
        {
            DataTable accountsTable = new();
            accountsTable.Columns.Add("AccountId", typeof(string));
            accountsTable.Columns.Add("Name", typeof(string));
            accountsTable.Columns.Add("Type", typeof(string));
            accountsTable.Columns.Add("Subtype", typeof(string));

            foreach (var account in dto.Accounts)
            {
                accountsTable.Rows.Add(account.AccountId, account.Name, account.Type, account.Subtype);
            }

            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                await using (SqlCommand command = new SqlCommand("usp_UpdateTokenAndSyncEntities", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserId", dto.UserId);
                    command.Parameters.AddWithValue("@AccessToken", dto.AccessToken);
                    command.Parameters.AddWithValue("@Institution", JsonConvert.SerializeObject(dto.Institution));
                    
                    SqlParameter accountsParameter = command.Parameters.AddWithValue("@Accounts", accountsTable);
                    accountsParameter.SqlDbType = SqlDbType.Structured;
                    accountsParameter.TypeName = "dbo.AccountDtoType";

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        return false;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
