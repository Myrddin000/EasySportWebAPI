﻿CREATE TABLE [dbo].[Games]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Title] NVARCHAR(50) NOT NULL DEFAULT 'Match',
    [Date] DATE NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [ScoreA] INT NULL, 
    [ScoreB] INT NULL, 
    [TeamId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Games_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)