CREATE VIEW dbo.[vwTransferPlacement]
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

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[24] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Placement"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 289
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "PlacementStatus"
            Begin Extent = 
               Top = 445
               Left = 105
               Bottom = 588
               Right = 301
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 426
               Left = 354
               Bottom = 546
               Right = 544
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlacementBase"
            Begin Extent = 
               Top = 369
               Left = 588
               Bottom = 474
               Right = 776
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization_2"
            Begin Extent = 
               Top = 9
               Left = 520
               Bottom = 129
               Right = 708
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization_1"
            Begin Extent = 
               Top = 137
               Left = 516
               Bottom = 257
               Right = 706
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransferPlacement';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Column = 2385
         Alias = 3405
         Table = 1455
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransferPlacement';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransferPlacement';

