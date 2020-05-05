CREATE TABLE [dbo].[MessageBox] (
    [MessageId]         INT            IDENTITY (1, 1) NOT NULL,
    [MessageTitle]      NVARCHAR (255) NULL,
    [SenderUserId]      NVARCHAR (128) NULL,
    [SenderUserName]    NVARCHAR (MAX) NULL,
    [RecipientUserId]   NVARCHAR (128) NULL,
    [RecipientUserName] NVARCHAR (MAX) NULL,
    [MessageDate]       DATE           NULL,
    [MessageContent]    NVARCHAR (MAX) NULL,
    [MessageStatus]     INT            NULL,
    CONSTRAINT [PK_MessageBox] PRIMARY KEY CLUSTERED ([MessageId] ASC)
);

