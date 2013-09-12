-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec  [dbo].[gs_login] 'lior','123'
CREATE PROCEDURE [dbo].[gs_login]
	-- Add the parameters for the stored procedure here
   @userName nvarchar(100),@pws nvarchar(100)
AS
BEGIN
declare @result int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT @result=COUNT(*)
  FROM [MEDAM].[dbo].[User]
   where [UserName]=@userName and PWS=@pws
   
   if @result> 0
   begin
    select 1
   end
   else
   begin
    select 0
   end
--select 1
--    -- Insert statements for procedure here
	
END
