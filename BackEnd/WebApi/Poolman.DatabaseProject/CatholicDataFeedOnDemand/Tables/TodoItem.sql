CREATE TABLE [CatholicDataFeedOnDemand].[TodoItem] (
    [id]          NVARCHAR (255)     CONSTRAINT [DF_TodoItem_id] DEFAULT (CONVERT([nvarchar](255),newid(),(0))) NOT NULL,
    [__createdAt] DATETIMEOFFSET (3) CONSTRAINT [DF_TodoItem___createdAt] DEFAULT (CONVERT([datetimeoffset](3),sysutcdatetime(),(0))) NOT NULL,
    [__updatedAt] DATETIMEOFFSET (3) NULL,
    [__version]   ROWVERSION         NOT NULL,
    [__deleted]   BIT                DEFAULT ((0)) NOT NULL,
    [text]        NVARCHAR (MAX)     NULL,
    [complete]    BIT                NULL,
    PRIMARY KEY NONCLUSTERED ([id] ASC)
);


GO
CREATE CLUSTERED INDEX [__createdAt]
    ON [CatholicDataFeedOnDemand].[TodoItem]([__createdAt] ASC);


GO
CREATE TRIGGER [CatholicDataFeedOnDemand].[TR_TodoItem_InsertUpdateDelete] ON [CatholicDataFeedOnDemand].[TodoItem]
		   AFTER INSERT, UPDATE, DELETE
		AS
		BEGIN
			SET NOCOUNT ON;
			IF TRIGGER_NESTLEVEL() > 3 RETURN;

			UPDATE [CatholicDataFeedOnDemand].[TodoItem] SET [CatholicDataFeedOnDemand].[TodoItem].[__updatedAt] = CONVERT (DATETIMEOFFSET(3), SYSUTCDATETIME())
			FROM INSERTED
			WHERE INSERTED.id = [CatholicDataFeedOnDemand].[TodoItem].[id]
		END