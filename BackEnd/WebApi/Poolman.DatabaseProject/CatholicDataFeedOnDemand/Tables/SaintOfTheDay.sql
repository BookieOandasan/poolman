CREATE TABLE [Saint].[SaintOfTheDay]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[publishdate] DATETIME           NULL,
    [title]       NVARCHAR (254)     NULL,
    [link]        NVARCHAR (254)     NULL,
    [summary]     NVARCHAR (MAX)     NULL
)
