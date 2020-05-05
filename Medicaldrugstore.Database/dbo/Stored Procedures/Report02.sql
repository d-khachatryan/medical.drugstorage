-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Report02
@StartDate date,
@TerminationDate date,
@OrganizationId int
AS
BEGIN

SELECT	'-' AS ProductName,
		'-' AS UnitTypeName,
		0.1 AS InitialQuantity,
		0.1 AS InQuantity1,
		0.1 AS InQuantity2,
		0.1 AS InQuantity3,
		0.1 AS OutQuantity,
		0.1 AS FinalQuantity,
		'01/01/2016' AS ExpirationDate
		
		

END
