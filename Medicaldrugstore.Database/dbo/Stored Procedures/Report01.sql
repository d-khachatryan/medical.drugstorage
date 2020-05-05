-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Report01]
@StartDate date,
@TerminationDate date,
@OrganizationId int
AS
BEGIN

SELECT	0 AS DiagnoseId,
		'-' AS DiagnoseCode,
		'-' AS DiagnoseName,
		0 AS PatientGroup,
		0 AS PatientInitialCount,
		0 AS PatientInCount,
		0 AS PatientOutCount,
		0 AS PatientFinalCount,
		0 AS PatientDrugReceivedCount
		
		

END
