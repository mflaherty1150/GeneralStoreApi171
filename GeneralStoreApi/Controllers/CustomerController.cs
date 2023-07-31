using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private GeneralStoreDb171Context _db;
    public CustomerController(GeneralStoreDb171Context db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromForm] CustomerEdit newCustomer)
    {
        Customer customer = new Customer()
        {
            Name = newCustomer.Name,
            Email = newCustomer.Email,
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = new List<Customer>(await _db.Customers.ToListAsync());
        return Ok(customers);
    }
}