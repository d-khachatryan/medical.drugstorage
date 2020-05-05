CREATE VIEW dbo.vwDrugClass
AS
SELECT     dbo.DrugClass.DrugClassId, dbo.DrugClass.DrugClassName, dbo.DrugClass.GenericName, dbo.DrugClass.ProductCategoryId, dbo.ProductCategory.ProductCategoryName, 
                      dbo.DrugClass.ProductGroupId, dbo.ProductGroup.ProductGroupName, dbo.DrugClass.ProductTypeId, dbo.ProductType.ProductTypeName, dbo.DrugClass.DrugTypeId, 
                      dbo.DrugType.DrugTypeName, dbo.DrugClass.DrugCategoryId, dbo.DrugCategory.DrugCategoryName, dbo.DrugClass.UnitItemQuantity, dbo.DrugClass.DrugClassStatus, 
                      dbo.DrugClass.StoreOrganizationId, dbo.Organization.OrganizationCode AS StoreOrganizationCode, dbo.Organization.OrganizationName AS StoreOrganizationName
FROM         dbo.DrugClass LEFT OUTER JOIN
                      dbo.Organization ON dbo.DrugClass.StoreOrganizationId = dbo.Organization.OrganizationId LEFT OUTER JOIN
                      dbo.DrugCategory ON dbo.DrugClass.DrugCategoryId = dbo.DrugCategory.DrugCategoryId LEFT OUTER JOIN
                      dbo.DrugType ON dbo.DrugClass.DrugTypeId = dbo.DrugType.DrugTypeId LEFT OUTER JOIN
                      dbo.ProductType ON dbo.DrugClass.ProductTypeId = dbo.ProductType.ProductTypeId LEFT OUTER JOIN
                      dbo.ProductGroup ON dbo.DrugClass.ProductGroupId = dbo.ProductGroup.ProductGroupId LEFT OUTER JOIN
                      dbo.ProductCategory ON dbo.DrugClass.ProductCategoryId = dbo.ProductCategory.ProductCategoryId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[35] 2[20] 3) )"
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
         Begin Table = "DrugClass"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "DrugCategory"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 126
               Right = 446
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DrugType"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 231
               Right = 201
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductType"
            Begin Extent = 
               Top = 126
               Left = 239
               Bottom = 231
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductGroup"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 339
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductCategory"
            Begin Extent = 
               Top = 234
               Left = 258
               Bottom = 339
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organization"
            Begin Extent = 
               Top = 18
               Left = 487
               Bottom = 174
               Right = 677
            End
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrugClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          DisplayFlags = 280
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
         Column = 2100
         Alias = 1980
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrugClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwDrugClass';

