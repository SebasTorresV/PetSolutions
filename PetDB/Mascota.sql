CREATE TABLE [dbo].[Mascota]
(
	[IdMascota] INT NOT NULL PRIMARY KEY identity, 
    [IdCliente] int not null,
    [Alias] NVARCHAR(50) NULL, 
    [Especie] NVARCHAR(50) NULL, 
    [Raza] NVARCHAR(50) NULL, 
    [ColorPelo] NVARCHAR(50) NULL, 
    [FechaNacimiento] DATETIME NULL
)
