CREATE TABLE [dbo].[Cliente]
(
	[IdCliente] INT NOT NULL PRIMARY KEY identity, 
    [NombreCompleto] NVARCHAR(50) NULL, 
    [Telefono] NCHAR(10) NULL, 
    [Email] NVARCHAR(200) NULL
)
