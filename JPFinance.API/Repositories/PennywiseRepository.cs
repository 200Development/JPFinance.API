using System.Data;
using System.Data.SqlClient;
using JPFinance.API.Interfaces;
using JPFinance.API.Models;
using JPFinance.API.Models.ViewModels;
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
            DataTable accountsTable = CreateDataTable(dto);

            try
            {
                await using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    await using(SqlCommand command = new SqlCommand("usp_UpdateTokenAndSyncEntities", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", dto.UserId);
                        command.Parameters.AddWithValue("@AccessToken", dto.AccessToken);
                        command.Parameters.AddWithValue("@Institution", JsonConvert.SerializeObject(dto.Institution));

                        SqlParameter accountsParameter = command.Parameters.AddWithValue("@Accounts", accountsTable);
                        accountsParameter.SqlDbType = SqlDbType.Structured;
                        accountsParameter.TypeName = "dbo.AccountDtoType";

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<AccountsViewModel>?> GetAccountsViewModel(int userId)
        {
            try
            {
                return await FetchAccountsFromDatabase(userId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private DataTable CreateDataTable(UpdateTokenAndSyncEntities dto)
        {
            DataTable accountsTable = new();
            accountsTable.Columns.Add("AccountId", typeof(string));
            accountsTable.Columns.Add("AvailableBalance", typeof(decimal));
            accountsTable.Columns.Add("CurrentBalance", typeof(decimal));
            accountsTable.Columns.Add("Limit", typeof(decimal));
            accountsTable.Columns.Add("IsoCurrency", typeof(string));
            accountsTable.Columns.Add("Name", typeof(string));
            accountsTable.Columns.Add("Type", typeof(string));
            accountsTable.Columns.Add("Subtype", typeof(string));

            foreach(var account in dto.Accounts)
            {
                accountsTable.Rows.Add(account.AccountId, account.AvailableBalance, account.CurrentBalance, account.Limit, account.IsoCurrencyCode, account.Name, account.Type, account.Subtype);
            }

            return accountsTable;
        }

        private async Task<List<AccountsViewModel>> FetchAccountsFromDatabase(int userId)
        {
            var viewModel = new List<AccountsViewModel>();

            await using(var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM vw_AllUserAccounts WHERE UserId = @UserId";
                await using(var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    await using(var reader = await command.ExecuteReaderAsync())
                    {
                        while(reader.Read())
                        {
                            viewModel.Add(ParseAccount(reader));
                        }
                    }
                }
            }

            return viewModel;
        }

        private AccountsViewModel ParseAccount(SqlDataReader reader)
        {
            var account = new AccountsViewModel
            {
                Name = reader["Name"].ToString() ?? string.Empty,
                Type = reader["Type"].ToString() ?? string.Empty,
                Subtype = reader["Subtype"].ToString() ?? string.Empty,
                IsoCurrencyCode = reader["IsoCurrencyCode"].ToString() ?? string.Empty,
                AvailableBalance = TryGetDecimal(reader, "AvailableBalance"),
                CurrentBalance = TryGetDecimal(reader, "CurrentBalance"),
                Limit = TryGetDecimal(reader, "Limit")
            };

            return account;
        }

        private decimal TryGetDecimal(SqlDataReader reader, string columnName)
        {
            if(reader[columnName] != DBNull.Value && decimal.TryParse(reader[columnName].ToString(), out decimal result))
            {
                return result;
            }

            return 0.0m;
        }
    }
}
