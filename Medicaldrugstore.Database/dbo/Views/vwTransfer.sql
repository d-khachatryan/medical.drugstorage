CREATE VIEW dbo.vwTransfer
AS
SELECT     dbo.Transfer.TransferId, dbo.Transfer.BaseDocumentId, dbo.BaseDocument.BaseDocumentName, dbo.Transfer.TransferDate, dbo.Transfer.DealInfo, dbo.Transfer.Comment, 
                      dbo.Transfer.SenderOrganizationId, dbo.Transfer.SenderTin, dbo.Transfer.SenderName, dbo.Transfer.SenderLocation, dbo.Transfer.SenderBankName, dbo.Transfer.SenderSupplyLocation, 
                      dbo.Transfer.SenderAccountNumber, dbo.Transfer.SenderHeadName, dbo.Transfer.SenderAccountantName, dbo.Transfer.SenderResponsibleName, dbo.Transfer.ReceiverOrganizationId, 
                      dbo.Transfer.ReceiverTin, dbo.Transfer.ReceiverName, dbo.Transfer.ReceiverLocation, dbo.Transfer.ReceiverBankName, dbo.Transfer.ReceiverSupplyLocation, 
                      dbo.Transfer.ReceiverAccountNumber, dbo.Transfer.ReceiverHeadName, dbo.Transfer.ReceiverAccountantName, dbo.Transfer.ReceiverResponsibleName, dbo.Transfer.TransferSum, 
                      dbo.Transfer.TransferTextSum, dbo.Transfer.TransferTotal, dbo.Transfer.TransferStatusId, dbo.TransferStatus.TransferStatusName
FROM         dbo.TransferStatus RIGHT OUTER JOIN
                      dbo.Transfer ON dbo.TransferStatus.TransferStatusId = dbo.Transfer.TransferStatusId LEFT OUTER JOIN
                      dbo.BaseDocument ON dbo.Transfer.BaseDocumentId = dbo.BaseDocument.BaseDocumentId

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[53] 4[11] 2[20] 3) )"
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
         Begin Table = "Transfer"
            Begin Extent = 
               Top = 12
               Left = 19
               Bottom = 554
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BaseDocument"
            Begin Extent = 
               Top = 2
               Left = 318
               Bottom = 107
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TransferStatus"
            Begin Extent = 
               Top = 426
               Left = 332
               Bottom = 531
               Right = 520
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
      Begin ColumnWidths = 27
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
         Column = 4065
         Alias = 4395
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransfer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransfer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwTransfer';

