CREATE TABLE [dbo].[Teams_Games]
(
	[TeamId] UNIQUEIDENTIFIER NOT NULL , 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Teams_Games_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id]), 
    CONSTRAINT [FK_Teams_Games_Users] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id])
)
