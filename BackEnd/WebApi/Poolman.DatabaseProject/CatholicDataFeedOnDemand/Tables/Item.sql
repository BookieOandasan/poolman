CREATE TABLE [CatholicDataFeedOnDemand].[Item] (
    [id]          NVARCHAR (255)     CONSTRAINT [DF_Item_id] DEFAULT (CONVERT([nvarchar](255),newid(),(0))) NOT NULL,
    [__createdAt] DATETIMEOFFSET (3) CONSTRAINT [DF_Item___createdAt] DEFAULT (CONVERT([datetimeoffset](3),sysutcdatetime(),(0))) NOT NULL,
    [__updatedAt] DATETIMEOFFSET (3) NULL,
    [__version]   ROWVERSION         NOT NULL,
    [__deleted]   BIT                DEFAULT ((0)) NOT NULL,
    PRIMARY KEY NONCLUSTERED ([id] ASC)
);


GO
CREATE CLUSTERED INDEX [__createdAt]
    ON [CatholicDataFeedOnDemand].[Item]([__createdAt] ASC);


GO
CREATE TRIGGER [CatholicDataFeedOnDemand].[TR_Item_InsertUpdateDelete] ON [CatholicDataFeedOnDemand].[Item]
		   AFTER INSERT, UPDATE, DELETE
		AS
		BEGIN
			SET NOCOUNT ON;
			IF TRIGGER_NESTLEVEL() > 3 RETURN;

			UPDATE [CatholicDataFeedOnDemand].[Item] SET [CatholicDataFeedOnDemand].[Item].[__updatedAt] = CONVERT (DATETIMEOFFSET(3), SYSUTCDATETIME())
			FROM INSERTED
			WHERE INSERTED.id = [CatholicDataFeedOnDemand].[Item].[id]
		END