CREATE VIEW dbo.vwReplacementDetails
AS
SELECT     dbo.Replacement.ReplacementDate, dbo.Replacement.ReplacementId, dbo.Replacement.ConfirmDate, dbo.Replacement.ReadyDate, dbo.Replacement.ProvisionDate, 
                      dbo.Replacement.ReceiveDate, dbo.Replacement.SourceOrganizationId, dbo.Replacement.ConfirmOrganizationId, dbo.Replacement.DestinationOrganizationId, dbo.Replacement.ReplacementSum, 
                      dbo.Replacement.ReplacementStatusId, dbo.Replacement.IsRetransfer, dbo.Replacement.RetransferId, dbo.Retransfer.RetransferDate, dbo.ReplacementStatus.ReplacementStatusCode, 
                      dbo.ReplacementStatus.ReplacementStatusName, Organization_1.OrganizationCode AS SourceOrganizationCode, Organization_1.OrganizationName AS SourceOrganizationName, 
                      dbo.Organization.OrganizationCode AS ConfirmOrganizationCode, dbo.Organization.OrganizationName AS ConfirmOrganizationName, 
                      Organization_2.OrganizationCode AS DestinationOrganizationCode, Organization_2.OrganizationName AS DestinationOrganizationName, dbo.Replacement.ReplacementBaseId, 
                      dbo.ReplacementBase.ReplacementBaseName, dbo.Replacement.ReplacementBaseDate, dbo.Replacement.ReplacementBaseText
FROM         dbo.Retransfer RIGHT OUTER JOIN
                      dbo.Replacement LEFT OUTER JOIN
                      dbo.ReplacementBase ON dbo.Replacement.ReplacementBaseId = dbo.ReplacementBase.ReplacementBaseId ON dbo.Retransfer.RetransferId = dbo.Replacement.RetransferId LEFT OUTER JOIN
                      dbo.ReplacementStatus ON dbo.Replacement.ReplacementStatusId = dbo.ReplacementStatus.ReplacementStatusId LEFT OUTER JOIN
                      dbo.Organization AS Organization_2 ON dbo.Replacement.DestinationOrganizationId = Organization_2.OrganizationId LEFT OUTER JOIN
                      dbo.Organization ON dbo.Replacement.ConfirmOrganizationId = dbo.Organization.OrganizationId LEFT OUTER JOIN
                      dbo.Organization AS Organization_1 ON dbo.Replacement.SourceOrganizationId = Organization_1.OrganizationId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[67] 4[26] 2[7] 3) )"
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
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ReplacementStatus"
            Begin Extent = 
               Top = 360
               Left = 407
               Bottom = 465
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Replacement"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 328
               Right = 252
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Retransfer"
            Begin Extent = 
               Top = 187
               Left = 626
               Bottom = 356
               Right = 841
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization_2"
            Begin Extent = 
               Top = 239
               Left = 405
               Bottom = 359
               Right = 595
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 120
               Left = 405
               Bottom = 240
               Right = 595
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Organization_1"
            Begin Extent = 
               Top = 0
               Left = 404
               Bottom = 120
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReplacementBase"
            Begin Extent = 
               Top = 302
               Left = 315
               Bottom = 407
               Right = 516
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwReplacementDetails';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'           End
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
         Column = 3165
         Alias = 2280
         Table = 1170
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwReplacementDetails';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwReplacementDetails';

