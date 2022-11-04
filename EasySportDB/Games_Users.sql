CREATE TABLE [dbo].[Games_Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [Participant] BIT NOT NULL, 
    [Absent] BIT NOT NULL, 
    CONSTRAINT [FK_Games_Users_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Games_Users_Games] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id])
)
