CREATE TABLE [dbo].[Mitkanim] (
    [MitkanNum]  INT           NOT NULL,
    [MitkanName] NVARCHAR (50) NOT NULL,
    [MitkanType] INT           NULL,
    [Kibolet]    INT           NULL,
    [RashutID]   INT           NULL,
    [RashutName] NVARCHAR (50) NULL,
    [Address]    NVARCHAR (50) NULL,
    [Manager]    NVARCHAR (50) NULL,
    [Phone]      NVARCHAR (50) NULL,
    [Fax]        NVARCHAR (20) NULL,
    [Tfusa]      INT           NULL,
    CONSTRAINT [PK_Mitkanim] PRIMARY KEY CLUSTERED ([MitkanNum] ASC)
);

