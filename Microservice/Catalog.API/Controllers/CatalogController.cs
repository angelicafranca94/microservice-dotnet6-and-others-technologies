using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;

    public CatalogController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);

        if(product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet, Route("[action]/{category}", Name = "GetProductByCategory")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategoy(string categoy)
    {
        if (categoy is null)
            return BadRequest("Invalid category");

        var products = await _repository.GetProductByCategory(categoy);

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        if (product is null)
            return BadRequest("Invalid product");

        await _repository.CreateProduct(product);

        return CreatedAtAction("GetProduct", new {id = product.Id}, product);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        if (product is null)
            return BadRequest("Invalid product");

        return Ok(await _repository.UpdateProduct(product));
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    public async Task<ActionResult> DeleteProductById(string id)
    {
        return Ok(await _repository.DeleteProduct(id));
    }
}
