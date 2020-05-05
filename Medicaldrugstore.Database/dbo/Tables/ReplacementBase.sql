CREATE TABLE [dbo].[ReplacementBase] (
    [ReplacementBaseId]   INT            IDENTITY (1, 1) NOT NULL,
    [ReplacementBaseCode] NVARCHAR (50)  NULL,
    [ReplacementBaseName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ReplacementBase] PRIMARY KEY CLUSTERED ([ReplacementBaseId] ASC)
);

