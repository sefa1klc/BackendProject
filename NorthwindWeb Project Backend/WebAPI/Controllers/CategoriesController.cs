using Business.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        if (result.Success)
        {
            return Ok(result); 
        } 
        return BadRequest(result);
    }
    
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _categoryService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}