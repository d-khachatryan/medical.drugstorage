-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageReplacement]
(	
@CalculationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT     dbo.Replacement.DestinationOrganizationId AS OrganizationId, dbo.ReplacementProduct.ProductId, dbo.ReplacementProductStorage.StorageId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.ReplacementProductStorage.Quantity,0)) AS Quantity, 
                      SUM(ISNULL(dbo.ReplacementProductStorage.ItemQuantity,0)) AS ItemQuantity,
                      SUM(ISNULL(dbo.ReplacementProductStorage.TotalCost,0)) 
                      AS TotalCost
FROM dbo.Replacement 
	INNER JOIN dbo.ReplacementProduct ON dbo.Replacement.ReplacementId = dbo.ReplacementProduct.ReplacementId 
	INNER JOIN dbo.ReplacementProductStorage ON dbo.ReplacementProduct.ReplacementProductId = dbo.ReplacementProductStorage.ReplacementProductId 
	INNER JOIN dbo.Product ON dbo.ReplacementProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ProvisionDate <= @CalculationDate
GROUP BY dbo.Replacement.DestinationOrganizationId, dbo.ReplacementProduct.ProductId, dbo.ReplacementProductStorage.StorageId, dbo.Drug.DrugName
)
