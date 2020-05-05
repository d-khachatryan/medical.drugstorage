CREATE TABLE [dbo].[Country] (
    [CountryId]   INT            IDENTITY (1, 1) NOT NULL,
    [CountryCode] NVARCHAR (50)  NULL,
    [CountryName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

