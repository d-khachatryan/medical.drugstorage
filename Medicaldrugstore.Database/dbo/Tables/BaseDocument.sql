CREATE TABLE [dbo].[BaseDocument] (
    [BaseDocumentId]   INT            IDENTITY (1, 1) NOT NULL,
    [BaseDocumentCode] NVARCHAR (50)  NULL,
    [BaseDocumentName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_BaseDocument] PRIMARY KEY CLUSTERED ([BaseDocumentId] ASC)
);

