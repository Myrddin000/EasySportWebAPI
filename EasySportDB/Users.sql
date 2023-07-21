CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Pseudo] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(255) NOT NULL, 
    [Role] INT NOT NULL DEFAULT 3, 
    CONSTRAINT [UK_Users_Pseudo] UNIQUE ([Pseudo]),
    CONSTRAINT [UK_Users_Email] UNIQUE ([Email]),
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])

)
