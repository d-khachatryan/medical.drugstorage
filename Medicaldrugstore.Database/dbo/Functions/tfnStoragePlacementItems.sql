-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStoragePlacementItems]
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
	SELECT dbo.Placement.StorageOrganizationId AS OrganizationId, 
	dbo.PlacementItemProduct.StorageId, 
	dbo.PlacementItemProduct.ProductId, 
	dbo.Drug.DrugName, 
	dbo.Placement.ReleaseDate AS ItemDate,
	dbo.PlacementItemProduct.Quantity, 
	dbo.PlacementItemProduct.ItemQuantity, 
	dbo.PlacementItemProduct.TotalCost
FROM dbo.Placement
	INNER JOIN dbo.PlacementItem ON dbo.Placement.PlacementId = dbo.PlacementItem.PlacementId 
	INNER JOIN dbo.PlacementItemProduct ON dbo.PlacementItem.PlacementItemId = dbo.PlacementItemProduct.PlacementItemId 
	INNER JOIN dbo.Product ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ReleaseDate BETWEEN @StartDate AND @TerminationDate
AND dbo.PlacementItemProduct.ProductId = @ProductId AND dbo.Placement.StorageOrganizationId = @OrganizationId
)
