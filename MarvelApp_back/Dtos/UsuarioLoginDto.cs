using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarvelApp_back.Dtos;

public partial class UsuarioLoginDto
{
    public required string email { get; set; }

    public required string uid { get; set; }
}
