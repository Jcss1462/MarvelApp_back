
using MarvelApp_back.Dtos;
using MarvelApp_back.Contexts;
using MarvelApp_back.Models;

namespace MarvelApp_back.Services;

public class UsuarioService : IUsuarioService
{
    MarvelDbContext context;

    public UsuarioService(MarvelDbContext dbcontext)
    {
        context = dbcontext;
    }

    public Usuario logIn(UsuarioLoginDto logindata)
    {
        Usuario? usuario = context.Usuarios
                         .Where(u => u.Correo == logindata.email && u.Uid == logindata.uid)
                         .Select(u => u)
                         .FirstOrDefault();

        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado con esas credenciales");
        }

        return usuario;
    }

    public void register(UsuarioRegisterDto newUsuarioDto)
    {
        Usuario? usuario = context.Usuarios
                         .Where(u => u.Correo == newUsuarioDto.email)
                         .Select(u => u)
                         .FirstOrDefault();

        if (usuario != null)
        {
            throw new Exception("El usuario con correo: "+ newUsuarioDto.email+", Ya esta registrado");
        }
        else
        {
            Usuario newUsuario = new Usuario();

            newUsuario.Correo = newUsuarioDto.email;
            newUsuario.Nombre = newUsuarioDto.name;
            newUsuario.Uid = newUsuarioDto.password;
            newUsuario.Identificacion = newUsuarioDto.cc;

            context.Usuarios.Add(newUsuario);
            context.SaveChanges();
        }
    }


    public void validateUserExistById(int idUser)
    {
        Usuario? usuario = context.Usuarios
                         .Where(u => u.IdUsuario == idUser)
                         .Select(u => u)
                         .FirstOrDefault();

        if (usuario == null)
        {
            throw new Exception("El usuario con id: "+ idUser+", No existe");
        }

    }
}

public interface IUsuarioService
{
    Usuario logIn(UsuarioLoginDto logindata);

    void register(UsuarioRegisterDto newUsuarioDto);

    void validateUserExistById(int idUser);
}