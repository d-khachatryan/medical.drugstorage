CREATE VIEW dbo.vwJunkConsumption
AS
SELECT     dbo.JunkConsumption.JunkConsumptionId, dbo.JunkConsumption.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkConsumption.ProductId, 
                      ISNULL(dbo.Drug.DrugName, N'-') + N' [' + ISNULL(dbo.Drug.Seria, N'-') + N'] ' + CONVERT(VARCHAR(10), dbo.Drug.ExpirationDate, 110) AS ProductName, 
                      dbo.JunkConsumption.JunkConsumptionDate, dbo.JunkConsumption.Quantity, dbo.JunkConsumption.ItemQuantity, dbo.JunkConsumption.UnitCost, dbo.JunkConsumption.TotalCost, 
                      dbo.JunkConsumption.JunkConsumptionStatusId, dbo.JunkConsumptionStatus.JunkConsumptionStatusName, dbo.JunkConsumption.JunkBaseId, dbo.JunkBase.JunkBaseName
FROM         dbo.JunkConsumption LEFT OUTER JOIN
                      dbo.JunkConsumptionStatus ON dbo.JunkConsumption.JunkConsumptionStatusId = dbo.JunkConsumptionStatus.JunkConsumptionStatusId LEFT OUTER JOIN
                      dbo.JunkBase ON dbo.JunkConsumption.JunkBaseId = dbo.JunkBase.JunkBaseId LEFT OUTER JOIN
                      dbo.Organization ON dbo.JunkConsumption.OrganizationId = dbo.Organization.OrganizationId LEFT OUTER JOIN
                      dbo.Product ON dbo.JunkConsumption.ProductId = dbo.Product.ProductId LEFT OUTER JOIN
                      dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[17] 4[44] 2[20] 3) )"
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
         Begin Table = "JunkConsumption"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 225
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JunkBase"
            Begin Extent = 
               Top = 254
               Left = 453
               Bottom = 359
               Right = 614
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 19
               Left = 329
               Bottom = 139
               Right = 519
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 75
               Left = 333
               Bottom = 195
               Right = 503
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Drug"
            Begin Extent = 
               Top = 50
               Left = 639
               Bottom = 170
               Right = 825
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "JunkConsumptionStatus"
            Begin Extent = 
               Top = 127
               Left = 673
               Bottom = 232
               Right = 904
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkConsumption';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 6300
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkConsumption';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkConsumption';

