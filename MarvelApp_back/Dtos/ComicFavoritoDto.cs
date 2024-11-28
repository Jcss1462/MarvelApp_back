using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarvelApp_back.Dtos;

public partial class ComicFavoritoDto
{
    public required int IdUsuario { get; set; }
    public required int IdComic { get; set; }

}
