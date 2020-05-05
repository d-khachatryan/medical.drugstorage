CREATE TABLE [dbo].[ConsumptionProduct] (
    [ConsumptionProductId] INT        IDENTITY (1, 1) NOT NULL,
    [ConsumptionId]        INT        NULL,
    [ProductId]            INT        NULL,
    [Quantity]             INT        NULL,
    [ItemQuantity]         FLOAT (53) NULL,
    [UnitCost]             FLOAT (53) NULL,
    [TotalCost]            FLOAT (53) NULL,
    CONSTRAINT [PK_ConsumptionProduct] PRIMARY KEY CLUSTERED ([ConsumptionProductId] ASC),
    CONSTRAINT [FK_ConsumptionProduct_Consumption] FOREIGN KEY ([ConsumptionId]) REFERENCES [dbo].[Consumption] ([ConsumptionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ConsumptionProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

