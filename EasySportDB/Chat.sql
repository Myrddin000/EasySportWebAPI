CREATE TABLE [dbo].[Chat]
(
	[TeamId] UNIQUEIDENTIFIER NOT NULL, 
    [EmitterPseudo] NVARCHAR(50) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Chat_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id]) 
)
