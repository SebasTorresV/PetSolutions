CREATE TABLE [dbo].[Pesos]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdMascota] INT NULL, 
    [Fecha] DATETIME NULL, 
    [Peso] NVARCHAR(50) NULL
)
