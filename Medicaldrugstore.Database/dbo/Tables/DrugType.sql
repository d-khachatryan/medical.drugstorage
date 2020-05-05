CREATE TABLE [dbo].[DrugType] (
    [DrugTypeId]   INT           IDENTITY (1, 1) NOT NULL,
    [DrugTypeCode] NVARCHAR (10) NULL,
    [DrugTypeName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_DrugType] PRIMARY KEY CLUSTERED ([DrugTypeId] ASC)
);

