CREATE TABLE [dbo].[Usuarios]
(
	[UsuarioID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NULL, 
    [Sobrenome] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [DataNascimento] DATETIME NULL
)
