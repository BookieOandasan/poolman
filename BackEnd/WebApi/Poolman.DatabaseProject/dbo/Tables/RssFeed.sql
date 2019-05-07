CREATE TABLE [dbo].[RssFeed] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Type]        NCHAR (50)     NULL,
    [PublishDate] DATETIME       NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Summary]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

