CREATE TABLE [dbo].[JunkProduct] (
    [JunkProductId]       INT        IDENTITY (1, 1) NOT NULL,
    [OrganizationId]      INT        NULL,
    [ProductId]           INT        NULL,
    [JunkProductDate]     DATE       NULL,
    [StorageId]           INT        NULL,
    [Quantity]            INT        NULL,
    [ItemQuantity]        FLOAT (53) NULL,
    [UnitCost]            FLOAT (53) NULL,
    [TotalCost]           FLOAT (53) NULL,
    [JunkProductStatusId] INT        NULL,
    [JunkBaseId]          INT        NULL,
    CONSTRAINT [PK_JunkProductId] PRIMARY KEY CLUSTERED ([JunkProductId] ASC),
    CONSTRAINT [FK_JunkProduct_JunkBase] FOREIGN KEY ([JunkBaseId]) REFERENCES [dbo].[JunkBase] ([JunkBaseId]),
    CONSTRAINT [FK_JunkProduct_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]),
    CONSTRAINT [FK_JunkProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_JunkProduct_Storage] FOREIGN KEY ([StorageId]) REFERENCES [dbo].[Storage] ([StorageId])
);

