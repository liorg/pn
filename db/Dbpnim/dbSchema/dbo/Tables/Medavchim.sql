CREATE TABLE [dbo].[Medavchim] (
    [MitkanID]    INT           NOT NULL,
    [MdNameFirst] NVARCHAR (30) NOT NULL,
    [MdNameLast]  NVARCHAR (30) NULL,
    [MdJob]       NVARCHAR (50) NULL,
    [MdPhone]     NVARCHAR (20) NULL,
    [MdSelular]   NVARCHAR (20) NULL,
    [MdFax]       NVARCHAR (20) NULL,
    [MdEmail]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Medavchim] PRIMARY KEY CLUSTERED ([MitkanID] ASC)
);

