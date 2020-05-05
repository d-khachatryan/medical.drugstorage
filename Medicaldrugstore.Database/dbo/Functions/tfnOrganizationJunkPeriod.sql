-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationJunkPeriod]
(	
@StartDate date,
@TerminationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT     dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkConsumption.ProductId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.JunkConsumption.Quantity,0)) AS Quantity, 
                      SUM(ISNULL(dbo.JunkConsumption.ItemQuantity,0)) AS ItemQuantity, 
                      SUM(ISNULL(dbo.JunkConsumption.TotalCost,0)) 
                      AS TotalCost
FROM         dbo.Organization INNER JOIN
                      dbo.JunkConsumption ON dbo.Organization.OrganizationId = dbo.JunkConsumption.OrganizationId INNER JOIN
                      dbo.Product ON dbo.JunkConsumption.ProductId = dbo.Product.ProductId INNER JOIN
                      dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE JunkConsumptionDate BETWEEN @StartDate AND @TerminationDate 
GROUP BY dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkConsumption.ProductId, dbo.Drug.DrugName

)
