CREATE TABLE [dbo].[Organization] (
    [OrganizationId]       INT            IDENTITY (10001, 1) NOT NULL,
    [RegionId]             INT            NULL,
    [GovermentId]          INT            NULL,
    [OrganizationCode]     NVARCHAR (50)  NULL,
    [OrganizationName]     NVARCHAR (255) NULL,
    [OrganizationLocation] NVARCHAR (500) NULL,
    [DeliveryLocation]     NVARCHAR (500) NULL,
    [RegistrationNumber]   NVARCHAR (50)  NULL,
    [BankId]               INT            NULL,
    [BankAccountNumber]    NVARCHAR (50)  NULL,
    [TinNumber]            NVARCHAR (50)  NULL,
    [HeadName]             NVARCHAR (50)  NULL,
    [AccountantName]       NVARCHAR (50)  NULL,
    [ResponsibleName]      NVARCHAR (50)  NULL,
    [IsOrganization]       BIT            NULL,
    [IsStorage]            BIT            NULL,
    [IsRegion]             BIT            NULL,
    [IsGoverment]          BIT            NULL,
    CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED ([OrganizationId] ASC),
    CONSTRAINT [FK_Organization_Bank] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Bank] ([BankId])
);

