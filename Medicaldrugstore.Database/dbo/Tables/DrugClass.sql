CREATE TABLE [dbo].[DrugClass] (
    [DrugClassId]         INT            IDENTITY (1, 1) NOT NULL,
    [DrugClassName]       NVARCHAR (512) NULL,
    [GenericName]         NVARCHAR (255) NULL,
    [ProductCategoryId]   INT            NULL,
    [ProductGroupId]      INT            NULL,
    [ProductTypeId]       INT            NULL,
    [DrugTypeId]          INT            NULL,
    [DrugCategoryId]      INT            NULL,
    [UnitItemQuantity]    INT            NULL,
    [DrugClassStatus]     BIT            NULL,
    [StoreOrganizationId] INT            NULL,
    CONSTRAINT [PK_DrugClass] PRIMARY KEY CLUSTERED ([DrugClassId] ASC),
    CONSTRAINT [FK_DrugClass_DrugCategory] FOREIGN KEY ([DrugCategoryId]) REFERENCES [dbo].[DrugCategory] ([DrugCategoryId]),
    CONSTRAINT [FK_DrugClass_DrugType] FOREIGN KEY ([DrugTypeId]) REFERENCES [dbo].[DrugType] ([DrugTypeId]),
    CONSTRAINT [FK_DrugClass_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory] ([ProductCategoryId]),
    CONSTRAINT [FK_DrugClass_ProductGroup] FOREIGN KEY ([ProductGroupId]) REFERENCES [dbo].[ProductGroup] ([ProductGroupId]),
    CONSTRAINT [FK_DrugClass_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([ProductTypeId])
);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[UpdateDrugClassDrugClass] 
   ON  [dbo].[DrugClass]
   AFTER INSERT,UPDATE
AS 
BEGIN

DELETE FROM dbo.DrugClass FROM dbo.DrugClass INNER JOIN
(
SELECT DrugClassId FROM dbo.DrugClass
EXCEPT
SELECT DrugClassId FROM dbo.Drug
INTERSECT
SELECT DrugClassId FROM dbo.PlacementItem
) AS T ON dbo.DrugClass.DrugClassId = T.DrugClassId 


END


GO
DISABLE TRIGGER [dbo].[UpdateDrugClassDrugClass]
    ON [dbo].[DrugClass];

