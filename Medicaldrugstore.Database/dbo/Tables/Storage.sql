CREATE TABLE [dbo].[Storage] (
    [StorageId]      INT            IDENTITY (1, 1) NOT NULL,
    [StorageCode]    NVARCHAR (50)  NULL,
    [StorageName]    NVARCHAR (255) NULL,
    [OrganizationId] INT            NULL,
    CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED ([StorageId] ASC),
    CONSTRAINT [FK_Storage_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId])
);

