CREATE TABLE [dbo].[ReplacementProductStorage] (
    [ReplacementProductStorageId] INT        IDENTITY (1, 1) NOT NULL,
    [ReplacementProductId]        INT        NULL,
    [StorageId]                   INT        NULL,
    [ProductId]                   INT        NULL,
    [Quantity]                    INT        NULL,
    [ItemQuantity]                FLOAT (53) NULL,
    [UnitCost]                    FLOAT (53) NULL,
    [TotalCost]                   FLOAT (53) NULL,
    CONSTRAINT [PK_ReplacementProductStorage] PRIMARY KEY CLUSTERED ([ReplacementProductStorageId] ASC),
    CONSTRAINT [FK_ReplacementProductStorage_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_ReplacementProductStorage_ReplacementProduct] FOREIGN KEY ([ReplacementProductId]) REFERENCES [dbo].[ReplacementProduct] ([ReplacementProductId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ReplacementProductStorage_Storage] FOREIGN KEY ([StorageId]) REFERENCES [dbo].[Storage] ([StorageId])
);

