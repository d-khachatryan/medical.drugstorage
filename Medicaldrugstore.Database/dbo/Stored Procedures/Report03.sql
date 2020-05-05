-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Report03 
@StartDate date,
@TerminationDate date,
@OrganizationId int,
@DiagnoseId int
AS
BEGIN

SELECT	0 AS PatientId,
		'-' AS PatientName,
		'01/01/2016' AS BirthDate,
		'-' AS PatientLocation,
		'-' AS Phone,
		0 AS DrugId,
		'-' AS DrugName

END
