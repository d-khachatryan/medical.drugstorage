CREATE VIEW dbo.vwDrug
AS
SELECT        dbo.Drug.DrugId, dbo.Drug.Seria, dbo.Drug.DrugName, dbo.Drug.UnitTypeId, dbo.UnitType.UnitTypeName, dbo.Drug.ExpirationDate, dbo.Drug.SupplierId, dbo.Supplier.SupplierName, dbo.Drug.CountryId, 
                         dbo.Country.CountryName, dbo.Drug.Manufacturer, dbo.Drug.UnitCost, dbo.Drug.DrugClassId, dbo.Drug.OrganizationId, dbo.Organization.OrganizationCode, dbo.Organization.OrganizationName, dbo.Drug.StoreOrganizationId, 
                         Organization_1.OrganizationCode AS StoreOrganizationCode, Organization_1.OrganizationName AS StoreOrganizationName, dbo.Drug.Quantity, dbo.Drug.TotalCost, dbo.Drug.DrugSourceId, dbo.DrugSource.DrugSourceName, 
                         dbo.Drug.ItemQuantity, dbo.Drug.Description, dbo.DrugClass.GenericName, dbo.DrugClass.ProductCategoryId, dbo.DrugClass.ProductGroupId, dbo.DrugClass.ProductTypeId, dbo.ProductCategory.ProductCategoryName, 
                         dbo.ProductGroup.ProductGroupName, dbo.ProductType.ProductTypeName, dbo.DrugClass.DrugTypeId, dbo.DrugClass.DrugCategoryId, dbo.DrugType.DrugTypeName, dbo.DrugCategory.DrugCategoryName
FROM            dbo.Drug LEFT OUTER JOIN
                         dbo.DrugType RIGHT OUTER JOIN
                         dbo.DrugClass LEFT OUTER JOIN
                         dbo.ProductGroup ON dbo.DrugClass.ProductGroupId = dbo.ProductGroup.ProductGroupId LEFT OUTER JOIN
                         dbo.ProductCategory ON dbo.DrugClass.ProductCategoryId = dbo.ProductCategory.ProductCategoryId ON dbo.DrugType.DrugTypeId = dbo.DrugClass.DrugTypeId ON 
                         dbo.Drug.DrugClassId = dbo.DrugClass.DrugClassId LEFT OUTER JOIN
                         dbo.DrugSource ON dbo.Drug.DrugSourceId = dbo.DrugSource.DrugSourceId LEFT OUTER JOIN
                         dbo.Organization AS Organization_1 ON dbo.Drug.StoreOrganizationId = Organization_1.OrganizationId LEFT OUTER JOIN
                         dbo.Organization ON dbo.Drug.OrganizationId = dbo.Organization.OrganizationId LEFT OUTER JOIN
                         dbo.UnitType ON dbo.Drug.UnitTypeId = dbo.UnitType.UnitTypeId LEFT OUTER JOIN
                         dbo.Country ON dbo.Drug.CountryId = dbo.Country.CountryId LEFT OUTER JOIN
                         dbo.Supplier ON dbo.Drug.SupplierId = dbo.Supplier.SupplierId LEFT OUTER JOIN
                         dbo.DrugCategory ON dbo.DrugClass.DrugCategoryId = dbo.DrugCategory.DrugCategoryId LEFT OUTER JOIN
                         dbo.ProductType ON dbo.DrugClass.ProductTypeId = dbo.ProductType.ProductTypeId

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
         Begin Table = "Drug"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrugType"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 111
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrugClass"
            Begin Extent = 
               Top = 114
               Left = 262
               Bottom = 234
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductGroup"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 231
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 339
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrugSource"
            Begin Extent = 
               Top = 234
               Left = 274
               Bottom = 324
               Right = 446
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization_1"
            Begin Extent = 
               Top = 324
               Left = 274
               Bottom = 444
               Right = 464
            End
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrug';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 342
               Left = 38
               Bottom = 462
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UnitType"
            Begin Extent = 
               Top = 444
               Left = 266
               Bottom = 549
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 462
               Left = 38
               Bottom = 567
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 552
               Left = 236
               Bottom = 657
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrugCategory"
            Begin Extent = 
               Top = 570
               Left = 38
               Bottom = 690
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductType"
            Begin Extent = 
               Top = 660
               Left = 260
               Bottom = 765
               Right = 437
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
         Column = 3000
         Alias = 2040
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrug';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrug';

