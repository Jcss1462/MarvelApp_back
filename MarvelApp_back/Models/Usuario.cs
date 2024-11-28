using System;
using System.Collections.Generic;

namespace MarvelApp_back.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public int Identificacion { get; set; }

    public string Uid { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<ComicFavorito> ComicFavoritos { get; set; } = new List<ComicFavorito>();
}
