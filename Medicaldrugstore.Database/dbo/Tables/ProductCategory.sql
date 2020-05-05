CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategoryId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProductCategoryCode] NVARCHAR (50)  NULL,
    [ProductCategoryName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC)
);

