CREATE TABLE [dbo].[RetransferStatus] (
    [RetransferStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [RetransferStatusCode] NVARCHAR (50)  NULL,
    [RetransferStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_RetransferStatus] PRIMARY KEY CLUSTERED ([RetransferStatusId] ASC)
);

