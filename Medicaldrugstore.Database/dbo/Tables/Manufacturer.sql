CREATE TABLE [dbo].[Manufacturer] (
    [ManufacturerId]   INT            IDENTITY (1, 1) NOT NULL,
    [ManufacturerCode] NVARCHAR (50)  NULL,
    [ManufacturerName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED ([ManufacturerId] ASC)
);

