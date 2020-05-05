CREATE TABLE [dbo].[ProductType] (
    [ProductTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProductTypeCode] NVARCHAR (50)  NULL,
    [ProductTypeName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([ProductTypeId] ASC)
);

