-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [CatholicDataFeedOnDemand].[GetRssFeedByDate]
@type varchar(100)
   

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT TOP (1000) [id]
      ,[__createdAt]
      ,[__updatedAt]
      ,[__version]
      ,[__deleted]
      ,[type]
      ,[publishdate]
      ,[title]
      ,[link]
      ,[summary]
  FROM [CatholicDataFeedOnDemand].[RssFeed]
  where Datepart(year,getdate()) = Datepart(year,publishdate)
    and  Datepart(day,getdate()) =Datepart(day,publishdate)
    and Datepart(month,getdate()) = Datepart(month,publishdate)
    and type = @type
END
