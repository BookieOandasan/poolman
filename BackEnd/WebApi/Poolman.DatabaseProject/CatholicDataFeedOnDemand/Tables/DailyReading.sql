CREATE TABLE Reading.[DailyReading]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[publishdate] DATETIME           NULL,
    [title]       NVARCHAR (254)     NULL,
    [link]        NVARCHAR (254)     NULL,
    [summary]     NVARCHAR (MAX)     NULL, 
    [type]       NVARCHAR (254)      NULL
	

	--FOREIGN KEY ([sectionId]) REFERENCES Reading.DailyReadingSection(Id)
)
