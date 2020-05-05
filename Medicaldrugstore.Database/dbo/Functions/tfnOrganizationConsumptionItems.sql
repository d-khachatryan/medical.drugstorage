-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationConsumptionItems]
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
		dbo.ConsumptionProduct.ProductId,
		dbo.Drug.DrugName, 
		ConsumptionDate AS ItemDate,
		dbo.ConsumptionProduct.Quantity, 
		dbo.ConsumptionProduct.ItemQuantity, 
		dbo.ConsumptionProduct.TotalCost
FROM dbo.Organization 
INNER JOIN dbo.Consumption ON dbo.Organization.OrganizationId = dbo.Consumption.OrganizationId 
INNER JOIN dbo.ConsumptionProduct ON dbo.Consumption.ConsumptionId = dbo.ConsumptionProduct.ConsumptionId 
INNER JOIN dbo.Product ON dbo.ConsumptionProduct.ProductId = dbo.Product.ProductId 
INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE ConsumptionDate BETWEEN @StartDate AND @TerminationDate AND ConsumptionStatusId = 1
AND dbo.ConsumptionProduct.ProductId = @ProductId AND dbo.Consumption.OrganizationId = @OrganizationId
)
