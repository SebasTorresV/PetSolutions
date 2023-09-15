CREATE TABLE [dbo].[Vacunas]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdMascota] INT NULL, 
    [Fecha] DATETIME NULL, 
    [Enfermedad] NVARCHAR(50) NULL, 
    [FechaProxima] DATETIME NULL
)
