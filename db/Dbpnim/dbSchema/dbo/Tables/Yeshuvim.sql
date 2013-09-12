CREATE TABLE [dbo].[Yeshuvim] (
    [YeshuvNum]  INT           NOT NULL,
    [YeshuvName] NVARCHAR (50) NOT NULL,
    [Moaza]      INT           NULL,
    [Mahoz]      INT           NULL,
    CONSTRAINT [PK_Yishuvim] PRIMARY KEY CLUSTERED ([YeshuvNum] ASC)
);

