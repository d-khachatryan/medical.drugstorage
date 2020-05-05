-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Report05]
@ReportDate date,
@OrganizationId int
AS
BEGIN

SELECT	0 AS PlacementItemId,
		'-' AS DrugClassName,
		0 AS UnitTypeId,
		'-' AS UnitTypeName,
		'01/01/2016' AS ExpirationDate,
		0 AS RequestedQuantity,
		0 AS ProvidedQuantity,
		0 AS UnitCost,
		0 AS TotalCost
		
		

END
