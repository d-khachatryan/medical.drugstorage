-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Report07]
@StartDate date,
@TerminationDate date,
@MarzId int
AS
BEGIN

SELECT	0 AS OrganizationId,
		'-' AS OrganizationName,
		'-' AS DrugName,
		0 AS Quantity1,
		0 AS Quantity2,
		0 AS Quantity3,
		0 AS Quantity4
		
		

END
