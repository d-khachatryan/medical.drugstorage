CREATE TABLE [dbo].[Bank] (
    [BankId]   INT            IDENTITY (1, 1) NOT NULL,
    [BankCode] NVARCHAR (50)  NULL,
    [BankName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([BankId] ASC)
);

