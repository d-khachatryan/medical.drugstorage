CREATE TABLE [dbo].[ConsumptionStatus] (
    [ConsumptionStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [ConsumptionStatusCode] NVARCHAR (50)  NULL,
    [ConsumptionStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ConsumptionStatus] PRIMARY KEY CLUSTERED ([ConsumptionStatusId] ASC)
);

