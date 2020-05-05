CREATE VIEW dbo.vwPlacementItemProductDetails
AS
SELECT     dbo.PlacementItemProduct.PlacementItemProductId, dbo.PlacementItemProduct.PlacementItemId, dbo.PlacementItemProduct.ProductId, ISNULL(dbo.Drug.DrugName, N'-') 
                      + N' [' + ISNULL(dbo.Drug.Seria, N'-') + N'] ' + CONVERT(VARCHAR(10), dbo.Drug.ExpirationDate, 110) AS ProductName, dbo.PlacementItemProduct.Quantity, dbo.PlacementItemProduct.StorageId, 
                      dbo.Storage.StorageName, dbo.PlacementItemProduct.ItemQuantity, dbo.PlacementItemProduct.UnitCost, dbo.PlacementItemProduct.TotalCost
FROM         dbo.Storage RIGHT OUTER JOIN
                      dbo.PlacementItemProduct ON dbo.Storage.StorageId = dbo.PlacementItemProduct.StorageId LEFT OUTER JOIN
                      dbo.Drug RIGHT OUTER JOIN
                      dbo.Product ON dbo.Drug.DrugId = dbo.Product.DrugId ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "Storage"
            Begin Extent = 
               Top = 148
               Left = 426
               Bottom = 268
               Right = 586
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlacementItemProduct"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 200
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Drug"
            Begin Extent = 
               Top = 6
               Left = 491
               Bottom = 126
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 6
               Left = 283
               Bottom = 126
               Right = 453
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
         Column = 11460
         Alias = 2715
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwPlacementItemProductDetails';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwPlacementItemProductDetails';

