--Create Database MarvelAppBd;
--Drop Table ComicFavorito;
--Drop Table Usuario;

-- Tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY, -- Llave primaria autoincremental
    Nombre NVARCHAR(100) NOT NULL,          -- Nombre del usuario
    Identificacion INT NOT NULL,   -- Identificaci�n del usuario
    UID NVARCHAR(100) NOT NULL,
	Correo NVARCHAR(100) NOT NULL UNIQUE,   -- Correo �nico para registro
    FechaRegistro DATETIME DEFAULT GETDATE() -- Fecha de registro autom�tica
);

-- Tabla ComicFavorito
CREATE TABLE ComicFavorito (
    IdUsuario INT NOT NULL, -- Llave for�nea del usuario
    IdComic INT NOT NULL,   -- Id del c�mic favorito
    PRIMARY KEY (IdUsuario, IdComic), -- Llave primaria compuesta
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario) -- Relaci�n con Usuario
);
