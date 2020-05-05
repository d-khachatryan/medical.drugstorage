-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spOrganizationStore]
	@OrganizationId int,
	@StartDate date,
	@TerminationDate date
AS
BEGIN

DECLARE @OrganizationStore TABLE
(
  [OrganizationId] int, 
  [ProductId] int,
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
  [OutTotalCost] float,
  [StartDate] date,
  [TerminationDate] date
)

INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[InitialQuantity],[InitialItemQuantity],[InitialTotalCost],[TerminalQuantity],[TerminalItemQuantity],[TerminalTotalCost])
SELECT [OrganizationId],[ProductId], SUM([InitialQuantity]) AS [InitialQuantity], SUM([InitialItemQuantity]) AS [InitialItemQuantity], SUM([InitialTotalCost]) AS [InitialTotalCost], SUM([TerminalQuantity]) AS [TerminalQuantity], SUM([TerminalItemQuantity]) AS [TerminalItemQuantity], SUM([TerminalTotalCost]) AS [TerminalTotalCost] FROM
(
SELECT [OrganizationId],[ProductId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnOrganizationPlacement (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnOrganizationConsumption (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnSourceOrganizationReplacement (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnDestinationOrganizationReplacement (@StartDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity] AS [InitialQuantity],[ItemQuantity] AS [InitialItemQuantity],[TotalCost] AS [InitialTotalCost], 0 AS [TerminalQuantity], 0 AS [TerminalItemQuantity], 0 AS [TerminalTotalCost] FROM dbo.tfnOrganizationJunk (@StartDate) WHERE OrganizationId = @OrganizationId

UNION ALL

SELECT [OrganizationId],[ProductId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnOrganizationPlacement (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnOrganizationConsumption (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnSourceOrganizationReplacement (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnDestinationOrganizationReplacement (@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InitalQuantity], 0 AS [InitialItemQuantity], 0 AS [InitialtotalCost], [Quantity] AS [TerminalQuantity],[ItemQuantity] AS [TerminalItemQuantity],[TotalCost] AS [TerminalTotalCost] FROM dbo.tfnOrganizationJunk (@TerminationDate) WHERE OrganizationId = @OrganizationId

) AS T
GROUP BY [OrganizationId],[ProductId]



INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[InQuantity],[InItemQuantity],[InTotalCost],[OutQuantity],[OutItemQuantity],[OutTotalCost])
SELECT [OrganizationId],[ProductId], SUM([InQuantity]) AS [InQuantity], SUM([InItemQuantity]) AS [InItemQuantity], SUM([InTotalCost]) AS [InTotalCost], SUM([OutQuantity]) AS [OutQuantity], SUM([OutItemQuantity]) AS [OutItemQuantity], SUM([OutTotalCost]) AS [OutTotalCost] FROM
(
SELECT [OrganizationId],[ProductId], [Quantity] AS [InQuantity], [ItemQuantity] AS [InItemQuantity],[TotalCost] AS [InTotalCost], 0 AS [OutQuantity], 0 AS [OutItemQuantity], 0 AS [OutTotalCost] FROM dbo.tfnOrganizationPlacementPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity] AS [InQuantity], [ItemQuantity] AS [InItemQuantity],[TotalCost] AS [InTotalCost], 0 AS [OutQuantity], 0 AS [OutItemQuantity], 0 AS [OutTotalCost] FROM dbo.tfnDestinationOrganizationReplacementPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId

UNION ALL

SELECT [OrganizationId],[ProductId], 0 AS [InQuantity], 0 AS [InItemQuantity], 0 AS [InTotalCost], [Quantity] AS [OutQuantity], [ItemQuantity] AS [OutItemQuantity], [TotalCost] AS [OutTotalCost] FROM dbo.tfnOrganizationConsumptionPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InQuantity], 0 AS [InItemQuantity], 0 AS [InTotalCost], [Quantity] AS [OutQuantity], [ItemQuantity] AS [OutItemQuantity], [TotalCost] AS [OutTotalCost] FROM dbo.tfnSourceOrganizationReplacementPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], 0 AS [InQuantity], 0 AS [InItemQuantity], 0 AS [InTotalCost], [Quantity] AS [OutQuantity], [ItemQuantity] AS [OutItemQuantity], [TotalCost] AS [OutTotalCost] FROM dbo.tfnOrganizationJunkPeriod (@StartDate,@TerminationDate) WHERE OrganizationId = @OrganizationId

) AS T
GROUP BY [OrganizationId],[ProductId]

SELECT T.[OrganizationId],
		T.[ProductId],
		[DrugName],
		@StartDate AS [StartDate],
		@TerminationDate AS [TerminationDate],
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
INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
GROUP BY T.[OrganizationId],T.[ProductId],[DrugName],T.[StartDate],T.[TerminationDate]

END
