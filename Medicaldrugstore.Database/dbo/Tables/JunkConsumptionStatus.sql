CREATE TABLE [dbo].[JunkConsumptionStatus] (
    [JunkConsumptionStatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [JunkConsumptionStatusCode] NVARCHAR (50)  NULL,
    [JunkConsumptionStatusName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_JunkConsumptionStatus] PRIMARY KEY CLUSTERED ([JunkConsumptionStatusId] ASC)
);

