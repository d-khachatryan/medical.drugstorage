CREATE TABLE [dbo].[DrugCategory] (
    [DrugCategoryId]   INT           IDENTITY (1, 1) NOT NULL,
    [DrugCategoryCode] NVARCHAR (10) NULL,
    [DrugCategoryName] NVARCHAR (50) NULL,
    [UnitItemQuantity] INT           NULL,
    CONSTRAINT [PK_DrugCategory] PRIMARY KEY CLUSTERED ([DrugCategoryId] ASC)
);

