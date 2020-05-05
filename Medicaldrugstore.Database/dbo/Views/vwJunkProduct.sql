CREATE VIEW dbo.vwJunkProduct
AS
SELECT     dbo.JunkProduct.JunkProductId, dbo.JunkProduct.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.JunkProduct.ProductId, ISNULL(dbo.Drug.DrugName, 
                      N'-') + N' [' + ISNULL(dbo.Drug.Seria, N'-') + N'] ' + CONVERT(VARCHAR(10), dbo.Drug.ExpirationDate, 110) AS ProductName, dbo.JunkProduct.JunkProductDate, dbo.JunkProduct.StorageId, 
                      dbo.Storage.StorageName, dbo.JunkProduct.Quantity, dbo.JunkProduct.ItemQuantity, dbo.JunkProduct.UnitCost, dbo.JunkProduct.TotalCost, dbo.JunkProduct.JunkProductStatusId, 
                      dbo.JunkProductStatus.JunkProductStatusName, dbo.JunkProduct.JunkBaseId, dbo.JunkBase.JunkBaseName
FROM         dbo.JunkProductStatus RIGHT OUTER JOIN
                      dbo.JunkProduct ON dbo.JunkProductStatus.JunkProductStatusId = dbo.JunkProduct.JunkProductStatusId LEFT OUTER JOIN
                      dbo.JunkBase ON dbo.JunkProduct.JunkBaseId = dbo.JunkBase.JunkBaseId LEFT OUTER JOIN
                      dbo.Storage ON dbo.JunkProduct.StorageId = dbo.Storage.StorageId LEFT OUTER JOIN
                      dbo.Drug RIGHT OUTER JOIN
                      dbo.Product ON dbo.Drug.DrugId = dbo.Product.DrugId ON dbo.JunkProduct.ProductId = dbo.Product.ProductId LEFT OUTER JOIN
                      dbo.Organization ON dbo.JunkProduct.OrganizationId = dbo.Organization.OrganizationId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[18] 2[20] 3) )"
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
         Begin Table = "JunkProductStatus"
            Begin Extent = 
               Top = 279
               Left = 707
               Bottom = 384
               Right = 913
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JunkProduct"
            Begin Extent = 
               Top = 20
               Left = 23
               Bottom = 252
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JunkBase"
            Begin Extent = 
               Top = 340
               Left = 386
               Bottom = 445
               Right = 547
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Storage"
            Begin Extent = 
               Top = 129
               Left = 371
               Bottom = 249
               Right = 531
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Drug"
            Begin Extent = 
               Top = 56
               Left = 907
               Bottom = 176
               Right = 1093
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 61
               Left = 605
               Bottom = 181
               Right = 775
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 4
               Left = 909
               Bottom = 124
               Right = 1099
            End
           ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkProduct';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' DisplayFlags = 344
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
         Column = 10275
         Alias = 1185
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkProduct';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwJunkProduct';

