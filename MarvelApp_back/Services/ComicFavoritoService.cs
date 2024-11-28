using MarvelApp_back.Contexts;
using MarvelApp_back.Dtos;
using MarvelApp_back.Models;

namespace MarvelApp_back.Services;

public class ComicFavoritoService : IComicFavoritoService
{
    MarvelDbContext context;

    IUsuarioService usuarioService;

    public ComicFavoritoService(MarvelDbContext dbcontext, IUsuarioService service)
    {
        context = dbcontext;
        usuarioService = service;
    }

    public string getFavoriteComics(int id)
    {

        usuarioService.validateUserExistById(id);

        List<ComicFavorito> litaDeComics= context.ComicFavoritos
                         .Where(u => u.IdUsuario == id)
                         .Select(u => u)
                         .ToList();
        
        string comicsIds = string.Join(",", litaDeComics.Select(item => item.IdComic.ToString()));

        return comicsIds;

    }

    public void updateComicFavorito(ComicFavoritoDto comicFavoritoDto)
    {

        usuarioService.validateUserExistById(comicFavoritoDto.IdUsuario);

        ComicFavorito? favoritoEncontrado = context.ComicFavoritos
                         .Where(u => u.IdUsuario == comicFavoritoDto.IdUsuario && u.IdComic == comicFavoritoDto.IdComic)
                         .Select(u => u)
                         .FirstOrDefault();

        //si lo encuentro lo elimino
        if (favoritoEncontrado != null)
        {
            context.ComicFavoritos.Remove(favoritoEncontrado);
        }
        //si no lo encutro lo añado
        else {
            ComicFavorito newComicFavorito= new ComicFavorito();
            
            newComicFavorito.IdComic = comicFavoritoDto.IdComic;
            newComicFavorito.IdUsuario = comicFavoritoDto.IdUsuario;

            context.ComicFavoritos.Add(newComicFavorito);
        }

        context.SaveChanges();
    }
}

public interface IComicFavoritoService
{
    string getFavoriteComics(int id);

    void updateComicFavorito(ComicFavoritoDto comicFavoritoDto);
}