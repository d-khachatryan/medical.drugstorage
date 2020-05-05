CREATE VIEW dbo.vwOrganization
AS
SELECT     dbo.Organization.OrganizationId, dbo.Organization.RegionId, Region.OrganizationName AS RegionName, dbo.Organization.GovermentId, Goverment.OrganizationName AS GovermentName, 
                      dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.Organization.OrganizationLocation, dbo.Organization.DeliveryLocation, dbo.Organization.RegistrationNumber, 
                      dbo.Organization.BankId, dbo.Bank.BankName, dbo.Organization.BankAccountNumber, dbo.Organization.TinNumber, dbo.Organization.HeadName, dbo.Organization.AccountantName, 
                      dbo.Organization.ResponsibleName, dbo.Organization.IsOrganization, dbo.Organization.IsStorage, dbo.Organization.IsRegion, dbo.Organization.IsGoverment
FROM         dbo.Organization LEFT OUTER JOIN
                      dbo.Bank ON dbo.Organization.BankId = dbo.Bank.BankId LEFT OUTER JOIN
                      dbo.Organization AS Goverment ON dbo.Organization.GovermentId = Goverment.OrganizationId LEFT OUTER JOIN
                      dbo.Organization AS Region ON dbo.Organization.RegionId = Region.OrganizationId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[16] 2[37] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Bank"
            Begin Extent = 
               Top = 266
               Left = 774
               Bottom = 371
               Right = 934
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 59
               Left = 55
               Bottom = 439
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Goverment"
            Begin Extent = 
               Top = 119
               Left = 438
               Bottom = 218
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 28
               Left = 421
               Bottom = 88
               Right = 611
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
         Column = 1440
         Alias = 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwOrganization';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwOrganization';

