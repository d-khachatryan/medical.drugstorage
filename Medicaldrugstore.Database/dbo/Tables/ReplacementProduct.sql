CREATE TABLE [dbo].[ReplacementProduct] (
    [ReplacementProductId] INT        IDENTITY (1, 1) NOT NULL,
    [ReplacementId]        INT        NULL,
    [ProductId]            INT        NULL,
    [Quantity]             INT        NULL,
    [ItemQuantity]         FLOAT (53) NULL,
    [UnitCost]             FLOAT (53) NULL,
    [TotalCost]            FLOAT (53) NULL,
    CONSTRAINT [PK_ReplacementProduct] PRIMARY KEY CLUSTERED ([ReplacementProductId] ASC),
    CONSTRAINT [FK_ReplacementProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_ReplacementProduct_Replacement] FOREIGN KEY ([ReplacementId]) REFERENCES [dbo].[Replacement] ([ReplacementId]) ON DELETE CASCADE
);

