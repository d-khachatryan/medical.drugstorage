CREATE TABLE [dbo].[Supplier] (
    [SupplierId]   INT            IDENTITY (1, 1) NOT NULL,
    [SupplierCode] NVARCHAR (50)  NULL,
    [SupplierName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([SupplierId] ASC)
);

