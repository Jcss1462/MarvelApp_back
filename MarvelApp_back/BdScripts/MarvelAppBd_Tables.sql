--Create Database MarvelAppBd;
--Drop Table ComicFavorito;
--Drop Table Usuario;

-- Tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY, -- Llave primaria autoincremental
    Nombre NVARCHAR(100) NOT NULL,          -- Nombre del usuario
    Identificacion INT NOT NULL,   -- Identificación del usuario
    UID NVARCHAR(100) NOT NULL,
	Correo NVARCHAR(100) NOT NULL UNIQUE,   -- Correo único para registro
    FechaRegistro DATETIME DEFAULT GETDATE() -- Fecha de registro automática
);

-- Tabla ComicFavorito
CREATE TABLE ComicFavorito (
    IdUsuario INT NOT NULL, -- Llave foránea del usuario
    IdComic INT NOT NULL,   -- Id del cómic favorito
    PRIMARY KEY (IdUsuario, IdComic), -- Llave primaria compuesta
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario) -- Relación con Usuario
);
