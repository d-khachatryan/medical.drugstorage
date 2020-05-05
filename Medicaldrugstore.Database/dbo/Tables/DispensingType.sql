CREATE TABLE [dbo].[DispensingType] (
    [DispensingTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [DispensingTypeCode] NVARCHAR (50)  NULL,
    [DispensingTypeName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_DispensingType] PRIMARY KEY CLUSTERED ([DispensingTypeId] ASC)
);

