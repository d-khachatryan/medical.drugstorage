CREATE TABLE [dbo].[UserPermission] (
    [UserPermissionId]   INT            IDENTITY (1, 1) NOT NULL,
    [OrganizationId]     INT            NULL,
    [UserId]             NVARCHAR (50)  NOT NULL,
    [UserName]           NVARCHAR (MAX) NULL,
    [IsOrganizationUser] BIT            NULL,
    [IsStorageUser]      BIT            NULL,
    [IsGovermentUser]    BIT            NULL,
    [IsRegionUser]       BIT            NULL,
    [IsAdministrator]    BIT            NULL,
    CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED ([UserPermissionId] ASC)
);

