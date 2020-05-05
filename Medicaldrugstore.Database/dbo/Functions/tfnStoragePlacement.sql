-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStoragePlacement]
(	
@CalculationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.Placement.StorageOrganizationId AS OrganizationId, dbo.PlacementItemProduct.StorageId, dbo.PlacementItemProduct.ProductId, dbo.Drug.DrugName, 
          SUM(ISNULL(dbo.PlacementItemProduct.Quantity*-1,0)) AS Quantity, 
          SUM(ISNULL(dbo.PlacementItemProduct.ItemQuantity*-1,0)) AS ItemQuantity, 
          SUM(ISNULL(dbo.PlacementItemProduct.TotalCost*-1,0)) AS TotalCost
FROM dbo.Placement
	INNER JOIN dbo.PlacementItem ON dbo.Placement.PlacementId = dbo.PlacementItem.PlacementId 
	INNER JOIN dbo.PlacementItemProduct ON dbo.PlacementItem.PlacementItemId = dbo.PlacementItemProduct.PlacementItemId 
	INNER JOIN dbo.Product ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ReleaseDate <= @CalculationDate
GROUP BY dbo.Placement.StorageOrganizationId, dbo.PlacementItemProduct.StorageId, dbo.PlacementItemProduct.ProductId,
          dbo.Drug.DrugName
)
