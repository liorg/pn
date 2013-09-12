-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [gs_GetYeshuvim]
CREATE PROCEDURE [dbo].[gs_GetYeshuvim]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT  [YeshuvNum]
      ,[YeshuvName]
  FROM [MEDAM].[dbo].[Yeshuvim]
  order by [YeshuvNum] 
 
 END
