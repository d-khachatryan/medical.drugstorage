CREATE TABLE [dbo].[Status] (
    [StatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [StatusCode] NVARCHAR (50)  NULL,
    [StatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

