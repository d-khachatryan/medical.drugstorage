-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[tfnOrganizationJunkItems]
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
		dbo.JunkConsumption.ProductId, 
		dbo.Drug.DrugName, 
		JunkConsumptionDate AS ItemDate,
		dbo.JunkConsumption.Quantity,
		dbo.JunkConsumption.ItemQuantity,
		dbo.JunkConsumption.TotalCost
FROM dbo.Organization 
	INNER JOIN dbo.JunkConsumption ON dbo.Organization.OrganizationId = dbo.JunkConsumption.OrganizationId 
	INNER JOIN dbo.Product ON dbo.JunkConsumption.ProductId = dbo.Product.ProductId 
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId
WHERE JunkConsumptionDate BETWEEN @StartDate AND @TerminationDate 
AND dbo.JunkConsumption.ProductId = @ProductId AND dbo.JunkConsumption.OrganizationId = @OrganizationId
)
