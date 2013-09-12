CREATE TABLE [dbo].[AgeType] (
    [AgeId]      INT           IDENTITY (1, 1) NOT NULL,
    [BeginValue] INT           NULL,
    [EndValue]   INT           NULL,
    [AgeName]    NVARCHAR (50) NULL,
    CONSTRAINT [PK_AgeType] PRIMARY KEY CLUSTERED ([AgeId] ASC)
);

