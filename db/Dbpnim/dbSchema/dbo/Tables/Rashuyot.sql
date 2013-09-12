CREATE TABLE [dbo].[Rashuyot] (
    [Mahoz]      SMALLINT      NOT NULL,
    [RashutID]   INT           NOT NULL,
    [RashutName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Rashuyot] PRIMARY KEY CLUSTERED ([RashutID] ASC)
);

