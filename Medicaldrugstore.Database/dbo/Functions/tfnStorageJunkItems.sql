-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageJunkItems]
	(	
	@StartDate date,
	@TerminationDate date,
	@OrganizationId int,
	@ProductId int
	)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.JunkProduct.OrganizationId, 
	dbo.JunkProduct.StorageId, 
	dbo.JunkProduct.ProductId, 
	dbo.Drug.DrugName, 
	dbo.JunkProduct.JunkProductDate AS ItemDate,
	dbo.JunkProduct.Quantity, 
	dbo.JunkProduct.ItemQuantity, 
	dbo.JunkProduct.TotalCost
FROM dbo.JunkProduct
	INNER JOIN dbo.Product ON dbo.JunkProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE JunkProductDate BETWEEN @StartDate AND @TerminationDate AND JunkProductStatusId = 1
AND dbo.JunkProduct.ProductId = @ProductId AND dbo.JunkProduct.OrganizationId = @OrganizationId
)
