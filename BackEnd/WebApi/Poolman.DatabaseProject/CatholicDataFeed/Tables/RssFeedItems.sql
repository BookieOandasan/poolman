CREATE TABLE [CatholicDataFeed].[RssFeedItems] (
    [Id]          NVARCHAR (128)     NOT NULL,
    [Type]        NVARCHAR (MAX)     NULL,
    [PublishDate] DATETIME           NOT NULL,
    [Title]       NVARCHAR (MAX)     NULL,
    [Summary]     NVARCHAR (MAX)     NULL,
    [Version]     ROWVERSION         NOT NULL,
    [CreatedAt]   DATETIMEOFFSET (7) NOT NULL,
    [UpdatedAt]   DATETIMEOFFSET (7) NULL,
    [Deleted]     BIT                NOT NULL,
    CONSTRAINT [PK_CatholicDataFeed.RssFeedItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

