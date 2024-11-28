using MarvelApp_back.Dtos;
using MarvelApp_back.Services;
using MarvelApp_back.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarvelApp_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComicFavoritoController : ControllerBase
{
    IComicFavoritoService comicFavoritoService;
   
    public ComicFavoritoController(IComicFavoritoService service)
    {
        comicFavoritoService = service;
    }


    [HttpGet("GetFavoriteComics/{id}")]
    public IActionResult GetFavoriteComics(int id)
    {
        string comicFavoritos = comicFavoritoService.getFavoriteComics(id);
        return Ok(comicFavoritos);
    }


    [HttpPut("UpdateComicFavorito")]
    public IActionResult UpdateComicFavorito([FromBody] ComicFavoritoDto comicFavorito)
    {
        comicFavoritoService.updateComicFavorito(comicFavorito);
        return Ok();
    }


}