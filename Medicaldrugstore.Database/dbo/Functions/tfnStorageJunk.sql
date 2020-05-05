-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageJunk]
(	
@CalculationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.JunkProduct.OrganizationId, dbo.JunkProduct.StorageId, dbo.JunkProduct.ProductId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.JunkProduct.Quantity*-1,0)) AS Quantity, 
                      SUM(ISNULL(dbo.JunkProduct.ItemQuantity*-1,0)) AS ItemQuantity, 
                      SUM(ISNULL(dbo.JunkProduct.TotalCost*-1,0)) 
                      AS TotalCost
FROM dbo.JunkProduct
	INNER JOIN dbo.Product ON dbo.JunkProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE JunkProductDate <= @CalculationDate AND JunkProductStatusId = 1
GROUP BY dbo.JunkProduct.OrganizationId, dbo.JunkProduct.StorageId, dbo.JunkProduct.ProductId, dbo.Drug.DrugName

)
