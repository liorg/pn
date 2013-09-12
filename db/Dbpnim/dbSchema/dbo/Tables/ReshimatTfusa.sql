CREATE TABLE [dbo].[ReshimatTfusa] (
    [RashutId]   INT           NOT NULL,
    [RashutNmr]  INT           IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    [ShemNimaan] NVARCHAR (50) NOT NULL,
    [Tafkid]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_ReshimatTfusa] PRIMARY KEY CLUSTERED ([RashutId] ASC, [RashutNmr] ASC)
);

