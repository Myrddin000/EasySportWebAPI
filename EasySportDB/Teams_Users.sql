CREATE TABLE [dbo].[Teams_Users]
(
	[TeamId] UNIQUEIDENTIFIER NOT NULL , 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Role] INT NOT NULL DEFAULT 3, 
    CONSTRAINT [FK_Teams_Users_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id]), 
    CONSTRAINT [FK_Teams_Users_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
