CREATE TABLE [dbo].[JunkProductStatus] (
    [JunkProductStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [JunkProductStatusCode] NVARCHAR (50)  NULL,
    [JunkProductStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_JunkProductStatus] PRIMARY KEY CLUSTERED ([JunkProductStatusId] ASC)
);

