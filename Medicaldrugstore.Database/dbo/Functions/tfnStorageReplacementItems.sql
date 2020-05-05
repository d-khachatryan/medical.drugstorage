-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageReplacementItems]
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
SELECT dbo.Replacement.DestinationOrganizationId AS OrganizationId, 
		dbo.ReplacementProduct.ProductId, 
		dbo.ReplacementProductStorage.StorageId, 
		dbo.Drug.DrugName, 
		dbo.Replacement.ReceiveDate AS ItemDate,
		dbo.ReplacementProductStorage.Quantity, 
		dbo.ReplacementProductStorage.ItemQuantity,
		dbo.ReplacementProductStorage.TotalCost                     
FROM dbo.Replacement 
	INNER JOIN dbo.ReplacementProduct ON dbo.Replacement.ReplacementId = dbo.ReplacementProduct.ReplacementId 
	INNER JOIN dbo.ReplacementProductStorage ON dbo.ReplacementProduct.ReplacementProductId = dbo.ReplacementProductStorage.ReplacementProductId 
	INNER JOIN dbo.Product ON dbo.ReplacementProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ProvisionDate BETWEEN @StartDate AND @TerminationDate
AND dbo.ReplacementProduct.ProductId = @ProductId AND OrganizationId = @OrganizationId
)
