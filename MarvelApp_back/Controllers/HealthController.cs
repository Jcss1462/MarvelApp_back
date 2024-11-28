using MarvelApp_back.Dtos;
using MarvelApp_back.Services;
using MarvelApp_back.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarvelApp_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
   
    public HealthController()
    {
        
    }


    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok("MarvelAppBack is running");
    }

}