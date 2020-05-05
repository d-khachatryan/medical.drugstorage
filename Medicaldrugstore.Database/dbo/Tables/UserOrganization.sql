CREATE TABLE [dbo].[UserOrganization] (
    [UserOrganizationId] INT            IDENTITY (1, 1) NOT NULL,
    [Id]                 NVARCHAR (128) NULL,
    [OrganizationId]     INT            NULL,
    [Psm01]              BIT            NULL,
    [Psm02]              BIT            NULL,
    [Psm03]              BIT            NULL,
    [Psm04]              BIT            NULL,
    [Psm05]              BIT            NULL,
    [Psm06]              BIT            NULL,
    [Psm07]              BIT            NULL,
    [Psm08]              BIT            NULL,
    [Psm09]              BIT            NULL,
    [Psm10]              BIT            NULL,
    CONSTRAINT [PK_UserOrganization] PRIMARY KEY CLUSTERED ([UserOrganizationId] ASC),
    CONSTRAINT [FK_UserOrganization_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId])
);

