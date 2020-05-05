-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnSourceOrganizationReplacementPeriod]
(	
@StartDate date,
@TerminationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT     dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.ReplacementProduct.ProductId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.ReplacementProduct.Quantity,0)) AS Quantity, 
                      SUM(ISNULL(dbo.ReplacementProduct.ItemQuantity,0)) AS ItemQuantity,
                      SUM(ISNULL(dbo.ReplacementProduct.TotalCost,0)) 
                      AS TotalCost
FROM         dbo.Organization INNER JOIN
                      dbo.Replacement ON dbo.Organization.OrganizationId = dbo.Replacement.SourceOrganizationId INNER JOIN
                      dbo.ReplacementProduct ON dbo.Replacement.ReplacementId = dbo.ReplacementProduct.ReplacementId INNER JOIN
                      dbo.Product ON dbo.ReplacementProduct.ProductId = dbo.Product.ProductId INNER JOIN
                      dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ProvisionDate BETWEEN @StartDate AND @TerminationDate 
GROUP BY dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.ReplacementProduct.ProductId, dbo.Drug.DrugName
)
