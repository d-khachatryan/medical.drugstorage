-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationConsumptionPeriod]
(	
@StartDate date,
@TerminationDate date
)
RETURNS TABLE 
AS
RETURN 
(
SELECT dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.ConsumptionProduct.ProductId, dbo.Drug.DrugName, 
                      SUM(ISNULL(dbo.ConsumptionProduct.Quantity,0)) AS Quantity, 
                      SUM(ISNULL(dbo.ConsumptionProduct.ItemQuantity,0)) AS ItemQuantity, 
                      SUM(ISNULL(dbo.ConsumptionProduct.TotalCost,0)) 
                      AS TotalCost
FROM dbo.Organization INNER JOIN
                      dbo.Consumption ON dbo.Organization.OrganizationId = dbo.Consumption.OrganizationId INNER JOIN
                      dbo.ConsumptionProduct ON dbo.Consumption.ConsumptionId = dbo.ConsumptionProduct.ConsumptionId INNER JOIN
                      dbo.Product ON dbo.ConsumptionProduct.ProductId = dbo.Product.ProductId INNER JOIN
                      dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ConsumptionDate BETWEEN @StartDate AND @TerminationDate AND ConsumptionStatusId = 1
GROUP BY dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.ConsumptionProduct.ProductId,
                      dbo.Drug.DrugName
)
