CREATE TABLE [dbo].[PlacementItem] (
    [PlacementItemId] INT        IDENTITY (1, 1) NOT NULL,
    [PlacementId]     INT        NULL,
    [Quantity]        INT        NULL,
    [DrugClassId]     INT        NULL,
    [ItemQuantity]    FLOAT (53) NULL,
    CONSTRAINT [PK_PlacementItem] PRIMARY KEY CLUSTERED ([PlacementItemId] ASC),
    CONSTRAINT [FK_PlacementItem_DrugClass] FOREIGN KEY ([DrugClassId]) REFERENCES [dbo].[DrugClass] ([DrugClassId]),
    CONSTRAINT [FK_PlacementItem_Placement] FOREIGN KEY ([PlacementId]) REFERENCES [dbo].[Placement] ([PlacementId]) ON DELETE CASCADE
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[UpdateItemQuantity] 
   ON  [dbo].[PlacementItem]
   AFTER INSERT,UPDATE
AS 
BEGIN

UPDATE dbo.PlacementItem SET ItemQuantity = CAST(dbo.PlacementItem.Quantity AS float)/CAST(dbo.DrugCategory.UnitItemQuantity AS float) FROM dbo.PlacementItem
INNER JOIN dbo.DrugClass ON dbo.PlacementItem.DrugClassId = dbo.DrugClass.DrugClassId
INNER JOIN dbo.DrugCategory ON dbo.DrugClass.DrugCategoryId = dbo.DrugCategory.DrugCategoryId
INNER JOIN inserted ON dbo.DrugClass.DrugClassId = inserted.DrugClassId

END
