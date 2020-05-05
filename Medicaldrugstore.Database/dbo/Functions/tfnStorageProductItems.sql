-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnStorageProductItems]
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
SELECT dbo.Drug.StoreOrganizationId AS OrganizationId, 
		dbo.Product.StorageId, 
		dbo.Product.ProductId, 
		dbo.Drug.DrugName, 
		dbo.Product.RegistrationDate AS ItemDate,
		dbo.Product.Quantity, 
		dbo.Product.ItemQuantity, 
		dbo.Product.TotalCost
FROM dbo.Product INNER JOIN
     dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE RegistrationDate BETWEEN @StartDate AND @TerminationDate
AND ProductId = @ProductId AND OrganizationId = @OrganizationId
)
