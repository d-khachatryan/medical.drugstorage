CREATE TABLE [dbo].[Level] (
    [LevelId]   INT           NOT NULL,
    [LevelCode] NVARCHAR (50) NULL,
    [LevelName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED ([LevelId] ASC)
);

