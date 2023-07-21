CREATE TABLE [dbo].[Games_Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [Available] BIT NULL, 
    [NotAvailable] BIT NULL, 
    [Pending] BIT NULL DEFAULT 1, 
    CONSTRAINT [FK_Games_Users_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Games_Users_Games] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id])
)
