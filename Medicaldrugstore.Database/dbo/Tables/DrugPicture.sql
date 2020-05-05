CREATE TABLE [dbo].[DrugPicture] (
    [FileId]      INT             IDENTITY (1, 1) NOT NULL,
    [FileName]    NVARCHAR (255)  NULL,
    [ContentType] NVARCHAR (100)  NULL,
    [Content]     VARBINARY (MAX) NULL,
    [FileType]    INT             NOT NULL,
    [DrugId]      INT             NOT NULL,
    CONSTRAINT [PK_DrugPicture] PRIMARY KEY CLUSTERED ([FileId] ASC),
    CONSTRAINT [FK_dbo.DrugPicture_dbo.Drug_DrugId] FOREIGN KEY ([DrugId]) REFERENCES [dbo].[Drug] ([DrugId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DrugId]
    ON [dbo].[DrugPicture]([DrugId] ASC);

