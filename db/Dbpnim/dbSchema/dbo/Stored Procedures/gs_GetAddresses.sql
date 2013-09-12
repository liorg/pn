-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec gs_GetAddresses
CREATE PROCEDURE [dbo].[gs_GetAddresses]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT  YeshuvNum
      ,[StNum]
      ,[StName],y.YeshuvName,m.MahozName,y.Moaza 
  FROM [MEDAM].[dbo].[Rehovot] r
   inner join    [MEDAM].[dbo].[Yeshuvim] y
   on r.StYeshuv=y.YeshuvNum
   inner join   [MEDAM].[dbo].[Mehozot] m
   on m.MahozNum=y.Mahoz
   ORDER BY MahozNum,YeshuvNum

 
 
 
 
 
	
END
