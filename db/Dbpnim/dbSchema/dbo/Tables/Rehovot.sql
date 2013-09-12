CREATE TABLE [dbo].[Rehovot] (
    [StYeshuv] INT           NOT NULL,
    [StNum]    INT           NOT NULL,
    [StName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Rehovot] PRIMARY KEY CLUSTERED ([StYeshuv] ASC, [StNum] ASC)
);

