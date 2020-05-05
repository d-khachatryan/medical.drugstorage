-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationPlacementItems]
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
SELECT dbo.Organization.OrganizationId, 
		dbo.Organization.OrganizationCode, 
		dbo.Organization.OrganizationName, 
		dbo.PlacementItemProduct.ProductId, 
		dbo.Drug.DrugName, 
		ReceiveDate AS ItemDate,
		dbo.PlacementItemProduct.Quantity,
		dbo.PlacementItemProduct.ItemQuantity,
		dbo.PlacementItemProduct.TotalCost
FROM dbo.Organization 
	INNER JOIN dbo.Placement ON dbo.Organization.OrganizationId = dbo.Placement.OrganizationId 
	INNER JOIN dbo.PlacementItem ON dbo.Placement.PlacementId = dbo.PlacementItem.PlacementId 
	INNER JOIN dbo.PlacementItemProduct ON dbo.PlacementItem.PlacementItemId = dbo.PlacementItemProduct.PlacementItemId 
	INNER JOIN dbo.Product ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ReceiveDate BETWEEN @StartDate AND @TerminationDate AND PlacementStatusId = 7
AND dbo.PlacementItemProduct.ProductId = @ProductId AND dbo.Placement.OrganizationId = @OrganizationId

)
