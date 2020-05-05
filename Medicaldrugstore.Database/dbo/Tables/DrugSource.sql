CREATE TABLE [dbo].[DrugSource] (
    [DrugSourceId]   INT            IDENTITY (1, 1) NOT NULL,
    [DrugSourceName] NVARCHAR (512) NULL,
    CONSTRAINT [PK_DrugSource] PRIMARY KEY CLUSTERED ([DrugSourceId] ASC)
);

