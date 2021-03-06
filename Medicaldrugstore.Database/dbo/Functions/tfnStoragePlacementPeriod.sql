﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStoragePlacementPeriod]
(	
@StartDate date,
@TerminationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.Placement.StorageOrganizationId AS OrganizationId, dbo.PlacementItemProduct.StorageId, dbo.PlacementItemProduct.ProductId, dbo.Drug.DrugName, 
          SUM(ISNULL(dbo.PlacementItemProduct.Quantity,0)) AS Quantity, 
          SUM(ISNULL(dbo.PlacementItemProduct.ItemQuantity,0)) AS ItemQuantity, 
          SUM(ISNULL(dbo.PlacementItemProduct.TotalCost,0)) AS TotalCost
FROM dbo.Placement
	INNER JOIN dbo.PlacementItem ON dbo.Placement.PlacementId = dbo.PlacementItem.PlacementId 
	INNER JOIN dbo.PlacementItemProduct ON dbo.PlacementItem.PlacementItemId = dbo.PlacementItemProduct.PlacementItemId 
	INNER JOIN dbo.Product ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ReleaseDate BETWEEN @StartDate AND @TerminationDate
GROUP BY dbo.Placement.StorageOrganizationId, dbo.PlacementItemProduct.StorageId, dbo.PlacementItemProduct.ProductId,
          dbo.Drug.DrugName
)
