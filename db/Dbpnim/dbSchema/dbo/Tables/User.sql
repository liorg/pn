CREATE TABLE [dbo].[User] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (150) NULL,
    [PWS]      NVARCHAR (150) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

