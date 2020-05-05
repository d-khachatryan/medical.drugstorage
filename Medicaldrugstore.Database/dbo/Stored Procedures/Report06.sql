-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Report06]
@StartDate date,
@TerminationDate date
AS
BEGIN

SELECT	'-' AS DrugName,
		'-' AS UnitTypeName,
		0 AS InitialCount,
		0.1 AS InitialCost,
		'-' AS ProvisionPlaceName,
		0 AS ProvisionCount,
		'01/01/2016' AS ProvisionDate,
		'-' AS OrganizationName,
		0 AS ReceivedCount,
		0 AS FinalCount,
		0.1 AS FinalCost,
		'01/01/2016' AS ExpirationDate
		
		

END
