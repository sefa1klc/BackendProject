using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    //Loosely coupled 
    IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        if (result.Success)
        {
            return Ok(result); 
        } 
        return BadRequest(result);
    }
 
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        if (result.Success) 
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Product product)
    {
        var result = _productService.Update(product);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}