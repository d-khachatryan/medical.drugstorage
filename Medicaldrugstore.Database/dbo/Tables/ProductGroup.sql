CREATE TABLE [dbo].[ProductGroup] (
    [ProductGroupId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProductGroupCode] NVARCHAR (50)  NULL,
    [ProductGroupName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupId] ASC)
);

