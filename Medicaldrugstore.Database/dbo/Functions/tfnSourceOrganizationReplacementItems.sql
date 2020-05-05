-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnSourceOrganizationReplacementItems]
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
dbo.ReplacementProduct.ProductId, 
dbo.Drug.DrugName, 
ProvisionDate AS ItemDate,
dbo.ReplacementProduct.Quantity,
dbo.ReplacementProduct.ItemQuantity,
dbo.ReplacementProduct.TotalCost
FROM dbo.Organization 
	INNER JOIN  dbo.Replacement ON dbo.Organization.OrganizationId = dbo.Replacement.SourceOrganizationId 
	INNER JOIN  dbo.ReplacementProduct ON dbo.Replacement.ReplacementId = dbo.ReplacementProduct.ReplacementId 
	INNER JOIN  dbo.Product ON dbo.ReplacementProduct.ProductId = dbo.Product.ProductId 
	INNER JOIN  dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ProvisionDate BETWEEN @StartDate AND @TerminationDate 
AND dbo.ReplacementProduct.ProductId = @ProductId AND dbo.Replacement.SourceOrganizationId = @OrganizationId

)
