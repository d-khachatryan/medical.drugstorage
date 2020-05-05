-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.[spCurrentStoreStatus] 
	@ProductId int,
	@PlacementItemId int
AS
BEGIN


DECLARE @CurrentDate date
DECLARE @StorageOrganizationId int
DECLARE @OrganizationId int
DECLARE @DrugClassId int

SET @CurrentDate = GETDATE()

SELECT @StorageOrganizationId = OrganizationId FROM dbo.Product
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId

SELECT @OrganizationId = OrganizationId FROM dbo.PlacementItem
	INNER JOIN dbo.Placement ON dbo.PlacementItem.PlacementId = dbo.Placement.PlacementId
	WHERE PlacementItemId = @PlacementItemId
	
SELECT @DrugClassId = DrugClassId FROM dbo.PlacementItem
	INNER JOIN dbo.Placement ON dbo.PlacementItem.PlacementId = dbo.Placement.PlacementId
	WHERE PlacementItemId = @PlacementItemId	
	
DECLARE @CurrentStore TABLE
(
  [Id] int, 
  [CurrentStoreCount] int,
  [CurrentRequestCount] int
)

INSERT INTO @CurrentStore (Id, CurrentStoreCount)
SELECT 1, SUM([Quantity]) FROM
(
SELECT T1.[ProductId],T1.[Quantity] FROM dbo.tfnStorageProduct (@CurrentDate) AS T1
	INNER JOIN dbo.Product ON T1.ProductId = dbo.Product.ProductId
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId 
	WHERE T1.OrganizationId = @StorageOrganizationId AND dbo.Drug.DrugClassId = @DrugClassId
UNION ALL
SELECT T2.[ProductId],T2.[Quantity] FROM dbo.tfnStoragePlacement (@CurrentDate) AS T2
	INNER JOIN dbo.Product ON T2.ProductId = dbo.Product.ProductId
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId 
	WHERE T2.OrganizationId = @StorageOrganizationId AND dbo.Drug.DrugClassId = @DrugClassId
UNION ALL
SELECT T3.[ProductId],T3.[Quantity] FROM dbo.tfnStorageReplacement (@CurrentDate) AS T3
	INNER JOIN dbo.Product ON T3.ProductId = dbo.Product.ProductId
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId 
	WHERE T3.OrganizationId = @StorageOrganizationId AND dbo.Drug.DrugClassId = @DrugClassId
UNION ALL
SELECT T4.[ProductId],T4.[Quantity] FROM dbo.tfnStorageJunk (@CurrentDate) AS T4
	INNER JOIN dbo.Product ON T4.ProductId = dbo.Product.ProductId
	INNER JOIN dbo.Drug ON dbo.Product.DrugId = dbo.Drug.DrugId 
	WHERE T4.OrganizationId = @StorageOrganizationId AND dbo.Drug.DrugClassId = @DrugClassId
) AS T
GROUP BY [ProductId]

INSERT INTO @CurrentStore (Id, CurrentRequestCount)
SELECT 1, SUM([Quantity]) FROM dbo.PlacementItem
	INNER JOIN dbo.Placement ON dbo.PlacementItem.PlacementId = dbo.Placement.PlacementId
	WHERE DrugClassId = @DrugClassId AND PlacementStatusId = 1  
	GROUP BY DrugClassId

SELECT Id, ISNULL(SUM([CurrentStoreCount]),0) AS CurrentStoreCount, ISNULL(SUM([CurrentRequestCount]),0) AS CurrentRequestCount FROM @CurrentStore
GROUP BY Id

END
