CREATE TABLE [dbo].[PlacementItemProduct] (
    [PlacementItemProductId] INT        IDENTITY (1, 1) NOT NULL,
    [PlacementItemId]        INT        NULL,
    [ProductId]              INT        NULL,
    [StorageId]              INT        NULL,
    [Quantity]               INT        NULL,
    [ItemQuantity]           FLOAT (53) NULL,
    [UnitCost]               FLOAT (53) NULL,
    [TotalCost]              FLOAT (53) NULL,
    CONSTRAINT [PK_PlacementItemProduct] PRIMARY KEY CLUSTERED ([PlacementItemProductId] ASC),
    CONSTRAINT [FK_PlacementItemProduct_PlacementItem] FOREIGN KEY ([PlacementItemId]) REFERENCES [dbo].[PlacementItem] ([PlacementItemId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PlacementItemProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

