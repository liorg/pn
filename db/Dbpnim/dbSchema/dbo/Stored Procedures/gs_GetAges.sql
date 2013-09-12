--exec gs_GetAddresses
create PROCEDURE [dbo].[gs_GetAges]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [AgeId]
      ,[BeginValue]
      ,[EndValue]
      ,[AgeName]
  FROM [MEDAM].[dbo].[AgeType]

end
