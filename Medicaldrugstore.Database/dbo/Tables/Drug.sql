CREATE TABLE [dbo].[Drug] (
    [DrugId]              INT            NOT NULL,
    [Seria]               NVARCHAR (50)  NULL,
    [DrugName]            NVARCHAR (255) NULL,
    [ExpirationDate]      DATE           NULL,
    [UnitTypeId]          INT            NULL,
    [OrganizationId]      INT            NULL,
    [StoreOrganizationId] INT            NULL,
    [DrugClassId]         INT            NULL,
    [DrugSourceId]        INT            NULL,
    [SupplierId]          INT            NULL,
    [CountryId]           INT            NULL,
    [Manufacturer]        NVARCHAR (255) NULL,
    [Quantity]            INT            NULL,
    [ItemQuantity]        FLOAT (53)     NULL,
    [UnitCost]            FLOAT (53)     NULL,
    [TotalCost]           FLOAT (53)     NULL,
    [Description]         NVARCHAR (255) NULL,
    CONSTRAINT [PK_Drug] PRIMARY KEY CLUSTERED ([DrugId] ASC),
    CONSTRAINT [FK_Drug_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId]),
    CONSTRAINT [FK_Drug_DrugClass] FOREIGN KEY ([DrugClassId]) REFERENCES [dbo].[DrugClass] ([DrugClassId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Drug_DrugSource] FOREIGN KEY ([DrugSourceId]) REFERENCES [dbo].[DrugSource] ([DrugSourceId]),
    CONSTRAINT [FK_Drug_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]),
    CONSTRAINT [FK_Drug_Organization1] FOREIGN KEY ([StoreOrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]),
    CONSTRAINT [FK_Drug_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([SupplierId]),
    CONSTRAINT [FK_Drug_UnitType] FOREIGN KEY ([UnitTypeId]) REFERENCES [dbo].[UnitType] ([UnitTypeId])
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[UpdateDrugClassDrug] 
   ON  dbo.Drug
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
DISABLE TRIGGER [dbo].[UpdateDrugClassDrug]
    ON [dbo].[Drug];

