CREATE TABLE [dbo].[UnitType] (
    [UnitTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [UnitTypeCode] NVARCHAR (50)  NULL,
    [UnitTypeName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_UnitType] PRIMARY KEY CLUSTERED ([UnitTypeId] ASC)
);

