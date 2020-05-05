
CREATE VIEW [dbo].[vwPlacement]
AS
SELECT     dbo.Placement.PlacementId, dbo.Placement.PlacementDate, dbo.Placement.OrderOrganizationId, Organization_2.OrganizationCode AS OrderOrganizationCode, 
                      Organization_2.OrganizationName AS OrderOrganizationName, dbo.Placement.OrganizationId, Organization_1.OrganizationCode, Organization_1.OrganizationName, dbo.Placement.CorrectionDate, 
                      dbo.Placement.ConfirmDate, dbo.Placement.ReceiveDate, dbo.Placement.TransferId, dbo.Placement.IsTransfer, dbo.Placement.PlacementBaseId, dbo.PlacementBase.PlacementBaseName, 
                      dbo.Placement.PlacementBaseDate, dbo.Placement.PlacementBaseText, dbo.Placement.ReadyDate, dbo.Placement.StorageOrganizationId, 
                      dbo.Organization.OrganizationName AS StorageOrganizationName, dbo.Placement.PlacementStatusId, dbo.PlacementStatus.PlacementStatusName, dbo.Placement.ReleaseDate
FROM         dbo.Placement LEFT OUTER JOIN
                      dbo.PlacementStatus ON dbo.Placement.PlacementStatusId = dbo.PlacementStatus.PlacementStatusId LEFT OUTER JOIN
                      dbo.Organization ON dbo.Placement.StorageOrganizationId = dbo.Organization.OrganizationId LEFT OUTER JOIN
                      dbo.PlacementBase ON dbo.Placement.PlacementBaseId = dbo.PlacementBase.PlacementBaseId LEFT OUTER JOIN
                      dbo.Organization AS Organization_2 ON dbo.Placement.OrderOrganizationId = Organization_2.OrganizationId LEFT OUTER JOIN
                      dbo.Organization AS Organization_1 ON dbo.Placement.OrganizationId = Organization_1.OrganizationId

