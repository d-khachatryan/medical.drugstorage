-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spOrganizationStoreOuts]
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
  [ItemDate] date,
  [Quantity] int,
  [ItemQuantity] float,
  [TotalCost] float,
  [TypeName] nvarchar(50)
)

INSERT INTO @OrganizationStore ([OrganizationId],[ProductId],[ItemDate],[Quantity],[ItemQuantity],[TotalCost],[TypeName])
(
SELECT [OrganizationId],[ProductId], [ItemDate], [Quantity], [ItemQuantity],[TotalCost], N'Ծախս' AS TypeName FROM dbo.tfnOrganizationConsumptionItems (@StartDate,@TerminationDate, @OrganizationId, @ProductId)
UNION ALL
SELECT [OrganizationId],[ProductId], [ItemDate], [Quantity], [ItemQuantity],[TotalCost], N'Վերադարձեր' AS TypeName  FROM dbo.tfnSourceOrganizationReplacementItems (@StartDate,@TerminationDate, @OrganizationId, @ProductId)
UNION ALL
SELECT [OrganizationId],[ProductId], [ItemDate], [Quantity], [ItemQuantity],[TotalCost], N'Խոտանումներ' AS TypeName  FROM dbo.tfnOrganizationJunkItems (@StartDate,@TerminationDate, @OrganizationId, @ProductId)

)

SELECT T.[OrganizationId],
		T.[ProductId],
		[DrugName],
		[ItemDate],
		T.[Quantity],
		T.[ItemQuantity],
		T.[TotalCost],
		T.[TypeName] 
FROM @OrganizationStore AS T
INNER JOIN dbo.Product ON T.ProductId = dbo.Product.ProductId 
INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId


END
