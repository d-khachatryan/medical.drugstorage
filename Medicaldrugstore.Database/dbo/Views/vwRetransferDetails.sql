
CREATE VIEW [dbo].[vwRetransferDetails]
AS
SELECT     dbo.Retransfer.RetransferId, dbo.Retransfer.RetransferDate, dbo.Retransfer.BaseDocumentId, dbo.BaseDocument.BaseDocumentName, dbo.Retransfer.SenderOrganizationId, 
                      dbo.Organization.OrganizationName AS SenderOrganizationName, dbo.Organization.OrganizationLocation AS SenderOrganizationLocation, 
                      dbo.Organization.RegistrationNumber AS SenderRegistrationNumber, dbo.Organization.TinNumber AS SenderTinNumber, dbo.Bank.BankName AS SenderBankName, 
                      dbo.Retransfer.SenderHeadName, dbo.Retransfer.SenderAccountantName, dbo.Retransfer.SenderResponsibleName, dbo.Retransfer.ReceiverOrganizationId, 
                      Organization_1.OrganizationName AS ReceiverOrganizationName, Organization_1.OrganizationLocation AS ReceiverOrganizationLocation, 
                      Organization_1.RegistrationNumber AS ReceiverRegistrationNumber, Bank_1.BankName AS ReceiverBankName, Organization_1.TinNumber AS ReceiverTinNumber, 
                      dbo.Retransfer.ReceiverHeadName, dbo.Retransfer.ReceiverAccountantName, dbo.Retransfer.ReceiverResponsibleName, dbo.Retransfer.RetransferSum, dbo.Retransfer.RetransferTextSum, 
                      dbo.Retransfer.RetransferTotal, dbo.Retransfer.Comment
FROM         dbo.Bank AS Bank_1 RIGHT OUTER JOIN
                      dbo.Organization AS Organization_1 ON Bank_1.BankId = Organization_1.BankId RIGHT OUTER JOIN
                      dbo.Bank RIGHT OUTER JOIN
                      dbo.Organization ON dbo.Bank.BankId = dbo.Organization.BankId RIGHT OUTER JOIN
                      dbo.Retransfer ON dbo.Organization.OrganizationId = dbo.Retransfer.SenderOrganizationId LEFT OUTER JOIN
                      dbo.BaseDocument ON dbo.Retransfer.BaseDocumentId = dbo.BaseDocument.BaseDocumentId ON Organization_1.OrganizationId = dbo.Retransfer.ReceiverOrganizationId

