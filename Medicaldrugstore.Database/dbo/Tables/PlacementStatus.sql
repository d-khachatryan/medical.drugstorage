CREATE TABLE [dbo].[PlacementStatus] (
    [PlacementStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [PlacementStatusCode] NVARCHAR (50)  NULL,
    [PlacementStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_PlacementStatus] PRIMARY KEY CLUSTERED ([PlacementStatusId] ASC)
);

