CREATE TABLE [dbo].[ShiltonMekomi_test] (
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
    [MfTofesID]       INT           NOT NULL
);

