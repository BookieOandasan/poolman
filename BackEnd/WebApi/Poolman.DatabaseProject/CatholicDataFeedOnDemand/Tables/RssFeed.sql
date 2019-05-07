CREATE TABLE [CatholicDataFeedOnDemand].[RssFeed] (
    [id]          NVARCHAR (255)     CONSTRAINT [DF_RssFeed_id] DEFAULT (CONVERT([nvarchar](255),newid(),(0))) NOT NULL,
    [__createdAt] DATETIMEOFFSET (3) CONSTRAINT [DF_RssFeed___createdAt] DEFAULT (CONVERT([datetimeoffset](3),sysutcdatetime(),(0))) NOT NULL,
    [__updatedAt] DATETIMEOFFSET (3) NULL,
    [__version]   ROWVERSION         NOT NULL,
    [__deleted]   BIT                NOT NULL,
    [type]        NVARCHAR (MAX)     NULL,
    [publishdate] DATETIME           NULL,
    [title]       NVARCHAR (MAX)     NULL,
    [link]        NVARCHAR (MAX)     NULL,
    [summary]     NVARCHAR (MAX)     NULL
);


GO
CREATE CLUSTERED INDEX [__createdAt]
    ON [CatholicDataFeedOnDemand].[RssFeed]([__createdAt] ASC);

