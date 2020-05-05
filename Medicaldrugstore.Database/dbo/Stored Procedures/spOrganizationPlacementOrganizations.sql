-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spOrganizationPlacementOrganizations] 
	@UserId nvarchar(50)
AS
BEGIN

SELECT * FROM dbo.Organization
--INNER JOIN dbo.UserPermission ON dbo.Organization.OrganizationId = dbo.UserPermission.ItemId
--WHERE dbo.UserPermission.UserId = @UserId

END
