CREATE TABLE [dbo].[TransferStatus] (
    [TransferStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [TransferStatusCode] NVARCHAR (50)  NULL,
    [TransferStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_TransferStatus] PRIMARY KEY CLUSTERED ([TransferStatusId] ASC)
);

