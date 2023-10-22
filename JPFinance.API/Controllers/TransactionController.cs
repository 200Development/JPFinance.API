using JPFinance.API.Interfaces.Services;
using JPFinance.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JPFinance.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("sync")]
    public async Task<IActionResult> TransactionsSync([FromBody] TransactionsSyncRequest request)
    {
        var transactions = await _transactionService.GetTransactionsAsync(request);
            
        if (transactions == null) 
            return Problem("There was an error getting transactions from Plaid API", null, 500) ;
        if (!transactions.AddedTransactions.Any() && !transactions.ModifiedTransactions.Any())
            return NoContent();
        return Ok(transactions);
    } 
}