-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStorageSubStore]
	@OrganizationId int,
	@StartDate date,
	@TerminationDate date,
	@ProductId int
AS
BEGIN

DECLARE @OrganizationStore TABLE
(
  [OrganizationId] int, 
  [ProductId] int,
  [StorageId] int,
  [InitialQuantity] int,
  [InitialItemQuantity] float,
  [InitialTotalCost] float,
  [TerminalQuantity] int,
  [TerminalItemQuantity] float,
  [TerminalTotalCost] float,
  [InQuantity] int,
  [InItemQuantity] float,
  [InTotalCost] float,
  [OutQuantity] int,
  [OutItemQuantity] float,
  [OutTotalCost] float
)

INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[StorageId],[InitialQuantity],[InitialItemQuantity],[InitialTotalCost],[TerminalQuantity],[TerminalItemQuantity],[TerminalTotalCost])
SELECT [OrganizationId],[ProductId],[StorageId], SUM([InitialQuantity]) AS [InitialQuantity], SUM([InitialItemQuantity]) AS [InitialItemQuantity], SUM([InitialTotalCost]) AS [InitialTotalCost], SUM([TerminalQuantity]) AS [TerminalQuantity], SUM([TerminalItemQuantity]) AS [TerminalItemQuantity], SUM([TerminalTotalCost]) AS [TerminalTotalCost] FROM
(
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnStorageProduct (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnStoragePlacement (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnStorageReplacement (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnStorageJunk (@StartDate) WHERE OrganizationId = @OrganizationId

UNION ALL

SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnStorageProduct (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnStoragePlacement (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnStorageReplacement (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnStorageJunk (@TerminationDate) WHERE OrganizationId = @OrganizationId

) AS T
GROUP BY [OrganizationId],[ProductId],[StorageId]



INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[StorageId],[InQuantity],[InItemQuantity],[InTotalCost],[OutQuantity],[OutItemQuantity],[OutTotalCost])
SELECT [OrganizationId],[ProductId],[StorageId], SUM([InQuantity]) AS [InQuantity], SUM([InItemQuantity]) AS [InItemQuantity], SUM([InTotalCost]) AS [InTotalCost], SUM([OutQuantity]) AS [OutQuantity], SUM([OutItemQuantity]) AS [OutItemQuantity], SUM([OutTotalCost]) AS [OutTotalCost] FROM
(
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InQuantity], [ItemQuantity] AS [InItemQuantity],[TotalCost] AS [InTotalCost], 0 AS [OutQuantity], 0 AS [OutItemQuantity], 0 AS [OutTotalCost] FROM dbo.tfnStorageProductPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], [Quantity] AS [InQuantity], [ItemQuantity] AS [InItemQuantity],[TotalCost] AS [InTotalCost], 0 AS [OutQuantity], 0 AS [OutItemQuantity], 0 AS [OutTotalCost] FROM dbo.tfnStorageReplacementPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId

UNION ALL

SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InQuantity], 0 AS [InItemQuantity], 0 AS [InTotalCost], [Quantity] AS [OutQuantity], [ItemQuantity] AS [OutItemQuantity], [TotalCost] AS [OutTotalCost] FROM dbo.tfnStoragePlacementPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId],[StorageId], 0 AS [InQuantity], 0 AS [InItemQuantity], 0 AS [InTotalCost], [Quantity] AS [OutQuantity], [ItemQuantity] AS [OutItemQuantity], [TotalCost] AS [OutTotalCost] FROM dbo.tfnStorageJunkPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId

) AS T
GROUP BY [OrganizationId],[ProductId],[StorageId]

SELECT T.[OrganizationId],
		T.[ProductId],
		[DrugName],
		[StorageName],
		SUM(ISNULL([InitialQuantity],0)) AS [InitialQuantity],
		SUM(ISNULL([InitialItemQuantity],0)) AS [InitialItemQuantity],
		SUM(ISNULL([InitialTotalCost],0)) AS [InitialTotalCost],
		SUM(ISNULL([TerminalQuantity],0)) AS [TerminalQuantity],
		SUM(ISNULL([TerminalItemQuantity],0)) AS [TerminalItemQuantity],
		SUM(ISNULL([TerminalTotalCost],0)) AS [TerminalTotalCost],
		SUM(ISNULL([InQuantity],0)) AS [InQuantity],
		SUM(ISNULL([InItemQuantity],0)) AS [InItemQuantity],
		SUM(ISNULL([InTotalCost],0)) AS [InTotalCost],
		SUM(ISNULL([OutQuantity],0)) AS [OutQuantity],
		SUM(ISNULL([OutItemQuantity],0)) AS [OutItemQuantity],
		SUM(ISNULL([OutTotalCost],0)) AS [OutTotalCost]
FROM @OrganizationStore AS T
INNER JOIN dbo.Product ON T.ProductId = dbo.Product.ProductId 
INNER JOIN dbo.Storage ON T.StorageId = dbo.Storage.StorageId 
INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE T.[OrganizationId] = @OrganizationId AND T.[ProductId] = @ProductId
GROUP BY T.[OrganizationId],T.[ProductId],[DrugName],[StorageName] 

END
