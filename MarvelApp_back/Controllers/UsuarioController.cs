using MarvelApp_back.Dtos;
using MarvelApp_back.Services;
using MarvelApp_back.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarvelApp_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    IUsuarioService usuarioService;
   
    public UsuarioController(IUsuarioService service)
    {
        usuarioService = service;
    }


    [HttpPost("Login")]
    public IActionResult Login([FromBody] UsuarioLoginDto usuarioLogin)
    {
        Usuario usuario = usuarioService.logIn(usuarioLogin);
        return Ok(usuario);
    }


    [HttpPost("Register")]
    public IActionResult Register([FromBody] UsuarioRegisterDto newUsuario)
    {
        usuarioService.register(newUsuario);
        return Ok();
    }


 

}