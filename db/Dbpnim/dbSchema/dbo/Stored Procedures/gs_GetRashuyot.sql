-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec [gs_GetYeshuvim]
CREATE PROCEDURE [dbo].[gs_GetRashuyot]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [Mahoz]
      ,[RashutID]
      ,[RashutName]
  FROM [dbo].[Rashuyot]
  ORDER BY [RashutID]


 
 END
