CREATE TABLE [dbo].[ShiltonMekomi] (
    [MefuneSysNum]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [MitkanID]        INT           NOT NULL,
    [MefuneID]        BIGINT        NULL,
    [MfFirstName]     NVARCHAR (30) NOT NULL,
    [MfLastName]      NVARCHAR (30) NOT NULL,
    [MfGender]        NVARCHAR (20) NULL,
    [MfFather]        NVARCHAR (50) NULL,
    [MfAge]           SMALLINT      NULL,
    [MfAddCityCode]   INT           NULL,
    [MfAddCityName]   NVARCHAR (30) NULL,
    [MfAddStreet]     NVARCHAR (50) NULL,
    [MfAddStreetCode] INT           NULL,
    [MfAddHouseNum]   INT           NULL,
    [MfDateIncome]    DATETIME      NULL,
    [MfDateOutcome]   DATETIME      NULL,
    [MfDateReport]    DATETIME      NOT NULL,
    [MfTofesID]       INT           NOT NULL,
    CONSTRAINT [PK_Mefunim] PRIMARY KEY CLUSTERED ([MefuneSysNum] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Mefunim]
    ON [dbo].[ShiltonMekomi]([MitkanID] ASC, [MfDateIncome] ASC, [MfFirstName] ASC, [MfLastName] ASC, [MfAddCityCode] ASC, [MfAddStreetCode] ASC, [MfAddHouseNum] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Mefunim_1]
    ON [dbo].[ShiltonMekomi]([MefuneID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Mitkan_Update]
    ON [dbo].[ShiltonMekomi]([MitkanID] ASC, [MfDateReport] ASC);

