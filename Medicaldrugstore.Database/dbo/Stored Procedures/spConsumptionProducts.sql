-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spConsumptionProducts] 
AS
BEGIN

SELECT dbo.Product.ProductId, ISNULL(DrugName, N'-') + N' [' + ISNULL(Seria, N'-') + N'] ' + CONVERT(VARCHAR(10), ExpirationDate, 110) AS ProductName
 FROM dbo.PlacementItemProduct 
 INNER JOIN dbo.Product ON dbo.PlacementItemProduct.ProductId = dbo.Product.ProductId
 INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId 

END
