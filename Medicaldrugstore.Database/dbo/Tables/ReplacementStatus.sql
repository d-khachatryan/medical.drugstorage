CREATE TABLE [dbo].[ReplacementStatus] (
    [ReplacementStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [ReplacementStatusCode] NVARCHAR (50)  NULL,
    [ReplacementStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ReplacementStatus] PRIMARY KEY CLUSTERED ([ReplacementStatusId] ASC)
);

