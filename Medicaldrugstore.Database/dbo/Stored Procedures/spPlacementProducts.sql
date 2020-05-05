-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spPlacementProducts] 
AS
BEGIN

SELECT ProductId, ISNULL(DrugName, N'-') + N' [' + ISNULL(Seria, N'-') + N'] ' + CONVERT(VARCHAR(10), ExpirationDate, 110) + ' ' + ISNULL(StorageName, N'-') AS ProductName
 FROM dbo.Product 
 INNER JOIN dbo.Drug ON dbo.Product .DrugId = dbo.Drug.DrugId 
 INNER JOIN dbo.Storage ON dbo.Product .StorageId = dbo.Storage .StorageId 

END
