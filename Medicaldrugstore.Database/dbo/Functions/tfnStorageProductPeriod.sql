-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageProductPeriod]
(	
@StartDate date,
@TerminationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.Drug.StoreOrganizationId AS OrganizationId, 
		dbo.Product.StorageId, 
		dbo.Product.ProductId, 
		dbo.Drug.DrugName, 
	SUM(dbo.Product.Quantity) AS Quantity, 
	SUM(dbo.Product.ItemQuantity) AS ItemQuantity, 
	SUM(dbo.Product.TotalCost) AS TotalCost
FROM dbo.Product INNER JOIN
     dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE RegistrationDate BETWEEN @StartDate AND @TerminationDate
GROUP BY dbo.Drug.StoreOrganizationId, dbo.Product.StorageId, dbo.Product.ProductId, dbo.Product.UnitCost, dbo.Drug.DrugName
)
