-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreOrganizations] 
	@UserId nvarchar(128)
AS
BEGIN

SELECT dbo.Organization.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName FROM dbo.Organization
INNER JOIN dbo.UserOrganization ON dbo.Organization.OrganizationId = dbo.UserOrganization.OrganizationId
WHERE IsStorage = 1
AND dbo.UserOrganization.Id = @UserId

END
