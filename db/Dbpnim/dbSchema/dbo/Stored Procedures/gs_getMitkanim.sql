-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec  [dbo].[gs_getMitkanim] 
CREATE PROCEDURE [dbo].[gs_getMitkanim]
	-- Add the parameters for the stored procedure here
  as
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT m.MitkanNum  ,m.MitkanName,r.RashutID,r.RashutName,me.MahozName,me.MahozNum 
		  FROM dbo.Mitkanim m
		  inner join dbo.Rashuyot r
		  on m.RashutID=r.RashutID
		  inner join dbo.Mehozot me
		  on me.MahozNum=r.Mahoz
		  
		  order by me.MahozNum ,r.RashutID, m.MitkanNum 
END
