using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
        private readonly GeneralStoreDb171Context _db;
    public TransactionController(GeneralStoreDb171Context db)
    {
            _db = db;
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransactionAsync([FromForm] TransactionCreate newTransaction)
    {
        var transaction = new Transaction()
        {
            ProductId = newTransaction.ProductId,
            CustomerId = newTransaction.CustomerId,
            Quantity = newTransaction.Quantity,
            DateOfTransaction = DateTime.Now,
        };

        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactionsAsync()
    {
        var transactions = new List<Transaction>(await _db.Transactions.ToListAsync());
        return Ok(transactions);
    }
}