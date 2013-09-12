
CREATE PROCEDURE [dbo].[gs_updateMefune]
	@MefuneSysNum bigint,@MfDateOutcome  datetime=null
 AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [MEDAM].[dbo].[ShiltonMekomi]
   SET [MfDateOutcome] = ISNULL(@MfDateOutcome,getdate())
 WHERE MefuneSysNum=@MefuneSysNum

end