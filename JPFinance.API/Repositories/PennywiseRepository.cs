using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using JPFinance.API.Interfaces.DTOs;
using JPFinance.API.Interfaces.Entities;
using JPFinance.API.Interfaces.Repositories;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Interfaces.ViewModels;
using JPFinance.API.Models.Responses;
using JPFinance.API.Models.ViewModels;
using Newtonsoft.Json;

namespace JPFinance.API.Repositories;

public class PennywiseRepository : IPennywiseRepository
{
    private readonly string _connectionString;

    public PennywiseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Updates the token and synchronizes the entities based on the provided data transfer object (DTO).
    /// </summary>
    /// <param name="dto">An instance of UpdateTokenAndSyncEntities containing details for the update and synchronization.</param>
    /// <returns>True if the operation is successful; otherwise, false.</returns>
    public async Task<bool> UpdateTokenAndSyncEntities(IUpdateTokenAndSyncEntities dto)
    {
        DataTable accountsTable = CreateDataTable(dto.Accounts) ?? throw new InvalidOperationException();

        try
        {
<<<<<<< HEAD
=======
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

        public async Task<List<AccountViewModel>?> GetAccountsViewModel(string userId)
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

        public async Task<List<RecurringTransaction>> GetPrePaydayExpenses(string userId)
        {
            try
            {
                var expenses = new List<RecurringTransaction>();

                await using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM vw_PrePaydayExpenses WHERE UserId = @UserId AND IsActive = 1 AND StreamType = 'Outflow'";
                    await using(var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        await using(var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                expenses.Add(ParseExpense(reader));
                            }
                        }
                    }
                }

                return expenses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<RecurringTransaction>> GetPostPaydayExpenses(string userId)
        {
            try
            {
                var expenses = new List<RecurringTransaction>();

                return expenses;
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

        private async Task<List<AccountViewModel>> FetchAccountsFromDatabase(string userId)
        {
            var viewModel = new List<AccountViewModel>();

>>>>>>> trunk
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
            //TODO: log error
            return false;
        }
    }

    /// <summary>
    /// Retrieves a list of account view models associated with a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user for whom the accounts are to be fetched.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="IAccountsViewModel"/> objects associated with the provided user.
    /// Returns null if no accounts are found or an error occurs.
    /// </returns>
    /// <remarks>
    /// This method queries the database view named 'vw_AllUserAccounts' using a parameterized query.
    /// It constructs a list of <see cref="IAccountsViewModel"/> objects by reading from the database,
    /// converting database fields into appropriate model properties.
    /// Any potential DBNull values in the balance or limit fields are handled safely.
    /// </remarks>
    public async Task<IList<IAccountsViewModel>?> GetAccountsViewModel(int userId)
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

    public async Task<IGetAccessTokenAndLatestCursorResponse?> GetAccessTokenAndLatestCursor(int itemId)
    {
        try
        {
            return await FetchAccessTokenAndCursorFromDatabase(itemId);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> SyncTransactionsForItem(ITransactionsDTO dto)
    {
        DataTable addedTransactions = CreateDataTable(dto.AddedTransactions);
        DataTable modifiedTransactions = CreateDataTable(dto.ModifiedTransactions);
        DataTable removedTransactions = CreateDataTable(dto.RemovedTransactions);

        try
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await using (var command = new SqlCommand("usp_SyncTransactions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                                       
                    if (!string.IsNullOrWhiteSpace(dto.NextCursor))
                    {
                        command.Parameters.AddWithValue("@NextCursor", dto.NextCursor);
                    }

                    if (addedTransactions != null)
                    {
                        SqlParameter addedTransactionsParameter =
                            command.Parameters.AddWithValue("@AddedTransactions", addedTransactions);
                        addedTransactionsParameter.SqlDbType = SqlDbType.Structured;
                        addedTransactionsParameter.TypeName = "dbo.TransactionDtoType";
                    }

                    if (modifiedTransactions != null)
                    {
                        SqlParameter modifiedTransactionsParameter =
                            command.Parameters.AddWithValue("@ModifiedTransactions", modifiedTransactions);
                        modifiedTransactionsParameter.SqlDbType = SqlDbType.Structured;
                        modifiedTransactionsParameter.TypeName = "dbo.TransactionDtoType";
                    }

                    if (removedTransactions != null)
                    {
                        SqlParameter removedTransactionsParameter =
                            command.Parameters.AddWithValue("@RemovedTransactions", removedTransactions);
                        removedTransactionsParameter.SqlDbType = SqlDbType.Structured;
                        removedTransactionsParameter.TypeName = "dbo.TransactionDtoType";
                    }
                    
                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        catch (SqlException sqlException)
        {
            return false;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    public static DataTable? CreateDataTable<T>(List<T> entities)
    {
        DataTable dataTable = new();

        // Check for an empty list
        if(!entities.Any())
        {
            return null;
        }

        // Use reflection to get the properties of T
        PropertyInfo[] properties = typeof(T).GetProperties();

        // Create columns for each property
        foreach(PropertyInfo prop in properties)
        {
            dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        // Populate rows
        foreach(var entity in entities)
        {
            var values = new object?[properties.Length];
            for(int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity, null);
            }
            dataTable.Rows.Add(values);
        }

        return dataTable;
    }

    private async Task<IList<IAccountsViewModel>> FetchAccountsFromDatabase(int userId)
    {
        var viewModel = new List<IAccountsViewModel>();

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

    private async Task<IGetAccessTokenAndLatestCursorResponse?> FetchAccessTokenAndCursorFromDatabase(int itemId)
    {
        var response = new GetAccessTokenAndLatestCursorResponse();

        await using(var connection = new SqlConnection(_connectionString))
        {
            try
            {
                await connection.OpenAsync();

                const string query = "SELECT TOP(1) i.AccessToken, ts.NextCursor " +
                                     "FROM dbo.Item i " +
                                     "LEFT JOIN (SELECT TOP(1) ItemId, NextCursor " +
                                     "  FROM dbo.TransactionsSync " +
                                     "  WHERE ItemId = 1 " +
                                     "  ORDER BY LastSyncedOn DESC) " +
                                     "ts ON i.ItemId = ts.ItemId " +
                                     "WHERE i.ItemId = 1";
                await using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemId);
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            response.AccessToken = reader["AccessToken"].ToString() ?? string.Empty;
                            response.NextCursor = reader["NextCursor"].ToString() ?? string.Empty;
                        }
                    }
                }
            }
<<<<<<< HEAD
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
=======

            return viewModel;
        }

        private AccountViewModel ParseAccount(SqlDataReader reader)
        {
            var account = new AccountViewModel
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

        private RecurringTransaction ParseExpense(SqlDataReader reader)
        {
            var expense = new RecurringTransaction
            {
                Category = reader["Category"].ToString() ?? string.Empty,
                Description = reader["Description"].ToString() ?? string.Empty,
                Frequency = reader["Frequency"].ToString() ?? string.Empty,
                StartDate = reader["StartDate"].ToString() ?? string.Empty,
                LastDate = reader["LastDate"].ToString() ?? string.Empty,
                LastAmount = TryGetDecimal(reader, "LastAmount"),
                AverageAmount = TryGetDecimal(reader, "AverageAmount"),

            };

            return expense;
        }

        private decimal TryGetDecimal(SqlDataReader reader, string columnName)
        {
            if(reader[columnName] != DBNull.Value && decimal.TryParse(reader[columnName].ToString(), out decimal result))
            {
                return result;
>>>>>>> trunk
            }
        }

        return response;
    }

    private static IAccountsViewModel ParseAccount(SqlDataReader reader)
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

    private static decimal TryGetDecimal(SqlDataReader reader, string columnName)
    {
        if(reader[columnName] != DBNull.Value && decimal.TryParse(reader[columnName].ToString(), out decimal result))
        {
            return result;
        }

        return 0.0m;
    }
}