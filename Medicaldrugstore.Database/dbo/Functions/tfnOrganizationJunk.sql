-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationJunk]
(	
@CalculationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT     dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkConsumption.ProductId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.JunkConsumption.Quantity*-1,0)) AS Quantity, 
                      SUM(ISNULL(dbo.JunkConsumption.ItemQuantity*-1,0)) AS ItemQuantity, 
                      SUM(ISNULL(dbo.JunkConsumption.TotalCost*-1,0)) 
                      AS TotalCost
FROM         dbo.Organization INNER JOIN
                      dbo.JunkConsumption ON dbo.Organization.OrganizationId = dbo.JunkConsumption.OrganizationId INNER JOIN
                      dbo.Product ON dbo.JunkConsumption.ProductId = dbo.Product.ProductId INNER JOIN
                      dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE JunkConsumptionDate <= @CalculationDate AND JunkConsumptionStatusId = 1
GROUP BY dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkConsumption.ProductId, dbo.Drug.DrugName

)
