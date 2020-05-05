CREATE TABLE [dbo].[Product] (
    [ProductId]        INT        IDENTITY (1, 1) NOT NULL,
    [RegistrationDate] DATE       NULL,
    [DrugId]           INT        NULL,
    [StorageId]        INT        NULL,
    [Quantity]         INT        NULL,
    [ItemQuantity]     FLOAT (53) NULL,
    [UnitCost]         FLOAT (53) NULL,
    [TotalCost]        FLOAT (53) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_Drug] FOREIGN KEY ([DrugId]) REFERENCES [dbo].[Drug] ([DrugId]) ON DELETE CASCADE
);

