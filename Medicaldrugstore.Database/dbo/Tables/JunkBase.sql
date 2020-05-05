CREATE TABLE [dbo].[JunkBase] (
    [JunkBaseId]   INT            IDENTITY (1, 1) NOT NULL,
    [JunkBaseCode] NVARCHAR (50)  NULL,
    [JunkBaseName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_JunkBase] PRIMARY KEY CLUSTERED ([JunkBaseId] ASC)
);

