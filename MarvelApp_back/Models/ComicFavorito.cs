using System;
using System.Collections.Generic;

namespace MarvelApp_back.Models;

public partial class ComicFavorito
{
    public int IdUsuario { get; set; }

    public int IdComic { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
