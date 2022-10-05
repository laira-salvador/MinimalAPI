CREATE TABLE [dbo].[Command]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Platform] VARCHAR(10) NOT NULL, 
    [CommandDesc] VARCHAR(75) NOT NULL, 
    [Command] VARCHAR(300) NOT NULL
)
