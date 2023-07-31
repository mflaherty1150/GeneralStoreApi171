using GeneralStoreApi.Data;
using GeneralStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private GeneralStoreDb171Context _db;
    public ProductController(GeneralStoreDb171Context db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] ProductRequest req)
    {
        Product newProduct = new()
        {
            Name = req.Name,
            Price = req.Price,
            QuantityInStock = req.Quantity
        };

        _db.Products.Add(newProduct);
        await _db.SaveChangesAsync();

        return Ok(newProduct);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = new List<Product>(await _db.Products.ToListAsync());
        return Ok(products);
    }
}