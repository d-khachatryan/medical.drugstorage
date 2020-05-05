CREATE TABLE [dbo].[Consumption] (
    [ConsumptionId]       INT  IDENTITY (1, 1) NOT NULL,
    [ConsumptionDate]     DATE NULL,
    [TerminationDate]     DATE NULL,
    [OrganizationId]      INT  NULL,
    [ConsumptionStatusId] INT  NULL,
    CONSTRAINT [PK_Consumption] PRIMARY KEY CLUSTERED ([ConsumptionId] ASC),
    CONSTRAINT [FK_Consumption_ConsumptionStatus] FOREIGN KEY ([ConsumptionStatusId]) REFERENCES [dbo].[ConsumptionStatus] ([ConsumptionStatusId])
);

