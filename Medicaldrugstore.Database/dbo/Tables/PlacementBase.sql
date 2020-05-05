CREATE TABLE [dbo].[PlacementBase] (
    [PlacementBaseId]   INT            IDENTITY (1, 1) NOT NULL,
    [PlacementBaseCode] NVARCHAR (50)  NULL,
    [PlacementBaseName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_PlacementBase] PRIMARY KEY CLUSTERED ([PlacementBaseId] ASC)
);

