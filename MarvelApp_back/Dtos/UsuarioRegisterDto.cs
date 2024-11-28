using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarvelApp_back.Dtos;

public partial class UsuarioRegisterDto
{
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required int cc { get; set; }
}
