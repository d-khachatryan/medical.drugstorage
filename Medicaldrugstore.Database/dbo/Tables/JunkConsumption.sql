CREATE TABLE [dbo].[JunkConsumption] (
    [JunkConsumptionId]       INT        IDENTITY (1, 1) NOT NULL,
    [OrganizationId]          INT        NULL,
    [ProductId]               INT        NULL,
    [JunkConsumptionDate]     DATE       NULL,
    [Quantity]                INT        NULL,
    [ItemQuantity]            FLOAT (53) NULL,
    [UnitCost]                FLOAT (53) NULL,
    [TotalCost]               FLOAT (53) NULL,
    [JunkConsumptionStatusId] INT        NULL,
    [JunkBaseId]              INT        NULL,
    CONSTRAINT [PK_JunkConsumptionId] PRIMARY KEY CLUSTERED ([JunkConsumptionId] ASC),
    CONSTRAINT [FK_JunkConsumption_JunkBase] FOREIGN KEY ([JunkBaseId]) REFERENCES [dbo].[JunkBase] ([JunkBaseId]),
    CONSTRAINT [FK_JunkConsumption_JunkConsumptionStatus] FOREIGN KEY ([JunkConsumptionStatusId]) REFERENCES [dbo].[JunkConsumptionStatus] ([JunkConsumptionStatusId]),
    CONSTRAINT [FK_JunkConsumption_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]),
    CONSTRAINT [FK_JunkConsumption_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

