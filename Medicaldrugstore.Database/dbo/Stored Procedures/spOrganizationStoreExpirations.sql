-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spOrganizationStoreExpirations]
	@OrganizationId int,
	@CalculationDate date,
	@ExpirationDays int
AS
BEGIN

DECLARE @OrganizationStore TABLE
(
  [OrganizationId] int, 
  [ProductId] int,
  [Quantity] int,
  [ItemQuantity] float,
  [TotalCost] float
 )

INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[Quantity],[ItemQuantity],[TotalCost])
SELECT [OrganizationId],[ProductId], SUM([Quantity]) AS [Quantity], SUM([ItemQuantity]), SUM([TotalCost]) FROM
(
SELECT [OrganizationId],[ProductId], [Quantity],[ItemQuantity],[TotalCost] FROM dbo.tfnOrganizationPlacement (@CalculationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity],[ItemQuantity],[TotalCost] FROM dbo.tfnOrganizationConsumption (@CalculationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity],[ItemQuantity],[TotalCost] FROM dbo.tfnSourceOrganizationReplacement (@CalculationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity],[ItemQuantity],[TotalCost] FROM dbo.tfnDestinationOrganizationReplacement (@CalculationDate) WHERE OrganizationId = @OrganizationId
UNION ALL
SELECT [OrganizationId],[ProductId], [Quantity],[ItemQuantity],[TotalCost] FROM dbo.tfnOrganizationJunk (@CalculationDate) WHERE OrganizationId = @OrganizationId

) AS T
GROUP BY [OrganizationId],[ProductId]

SELECT T.[OrganizationId],
		T.[ProductId],
		[DrugName],
		[ExpirationDate],
		[Seria],
		SUM(ISNULL(T.[Quantity],0)) AS [Quantity],
		SUM(ISNULL(T.[ItemQuantity],0)) AS [ItemQuantity],
		SUM(ISNULL(T.[TotalCost],0)) AS [TotalCost]		
FROM @OrganizationStore AS T
INNER JOIN dbo.Product ON T.ProductId = dbo.Product.ProductId 
INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE dbo.Drug.ExpirationDate <= DATEADD(day, @ExpirationDays, @CalculationDate)
GROUP BY T.[OrganizationId],T.[ProductId],[DrugName],[ExpirationDate],[Seria]

END
