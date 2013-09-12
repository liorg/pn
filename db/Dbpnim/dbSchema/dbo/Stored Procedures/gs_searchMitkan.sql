
--EXEC  [dbo].[gs_searchMitkan] @pOrderBy='Sum66 DESC' ,@pCurrentPage=1,@pPageSize=7

--EXEC  [dbo].[gs_searchMitkan]  @pOrderBy='Sum66 DESC' ,@pCurrentPage=1,@pPageSize=1 ,@RashutID=42650
CREATE PROCEDURE [dbo].[gs_searchMitkan]
  @pOrderBy nvarchar(100),@pCurrentPage int,@pPageSize tinyint,
  @MahozNum INT =NULL,@MitkanNum INT =NULL,@RashutID INT =NULL
  AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @intStartRow int;
	DECLARE @intEndRow int;
	
	SET @intStartRow = (@pCurrentPage -1) * @pPageSize + 1;
	SET @intEndRow   = @pCurrentPage * @pPageSize;  
	 
;with cteCount(MahozNum,MahozName, RashutID,RashutName,MitkanNum,MitkanName,MitkanAddress
        ,sumAll,sum3,Sum4To6,Sum7To18,Sum19To65,sum66)
as 
(
	select me.MahozNum , me.MahozName as MahozName,
		   r.RashutID as RashutID,  r.RashutName as RashutName, 
	       m.MitkanNum as MitkanNum,m.MitkanName as MitkanName,m.Address AS MitkanAddress
	,COUNT(MefuneSysNum) sumAll	
	,(select COUNT(*) from  dbo.ShiltonMekomi  where MitkanID= m.MitkanNum and MfDateOutcome is null and MfAge<=3 ) as sum3
	,(select COUNT(*) from  dbo.ShiltonMekomi  where MitkanID= m.MitkanNum and MfDateOutcome is null and MfAge>=4 and MfAge<=6 ) as Sum4To6
	,(select COUNT(*) from  dbo.ShiltonMekomi  where MitkanID= m.MitkanNum and MfDateOutcome is null and MfAge>=7 and MfAge<=18 ) as Sum7To18
	,(select COUNT(*) from  dbo.ShiltonMekomi  where MitkanID= m.MitkanNum and MfDateOutcome is null and MfAge>=19 and MfAge<=65 ) as Sum19To65
	,(select COUNT(*) from  dbo.ShiltonMekomi  where MitkanID= m.MitkanNum and MfDateOutcome is null and MfAge>=66 ) as sum66
	from dbo.Mitkanim m
		inner join dbo.ShiltonMekomi s
			on m.MitkanNum=s.MitkanID
			inner join dbo.Rashuyot r
				on r.RashutID=m.RashutID
				inner join dbo.Mehozot me
					on me.MahozNum=r.Mahoz
    where (@MitkanNum is null or m.MitkanNum=@MitkanNum) and
		  (@MahozNum is null or me.MahozNum=@MahozNum) and 
		  (@RashutID is null or r.RashutID=@RashutID)  
	group by m.MitkanNum,m.MitkanName ,m.Address ,r.RashutName,me.MahozName,me.MahozNum,r.RashutID) 
	
select Row,
		MahozNum,MahozName, RashutID,RashutName,MitkanNum,MitkanName,MitkanAddress
        ,sumAll,sum3,Sum4To6,Sum7To18,Sum19To65,sum66
   from(
	select ROW_NUMBER() OVER (ORDER BY 
         CASE @pOrderBy
         	WHEN 'MahozName ASC' THEN MahozName
			WHEN 'RashutName ASC' THEN RashutName
			WHEN 'MitkanName ASC' THEN MitkanName
			WHEN 'MitkanAddress ASC' THEN MitkanAddress
			
			WHEN 'SumAll ASC' THEN cast(sumAll as sql_variant)
			WHEN 'Sum3 ASC' THEN cast(sum3 as sql_variant)
			WHEN 'Sum4To6 ASC' THEN cast(Sum4To6 as sql_variant)
			WHEN 'Sum7To18 ASC' THEN cast(Sum7To18 as sql_variant)
			WHEN 'Sum19To65 ASC' THEN cast(Sum19To65 as sql_variant)
			WHEN 'Sum66 ASC' THEN cast(sum66 as sql_variant)
		END ASC,
		CASE @pOrderBy
			WHEN 'MahozName DESC' THEN MahozName
			WHEN 'RashutName DESC' THEN RashutName
			WHEN 'MitkanName DESC' THEN MitkanName
			WHEN 'MitkanAddress DESC' THEN MitkanAddress
			
			WHEN 'SumAll DESC' THEN cast(sumAll as sql_variant)
			WHEN 'Sum3 DESC' THEN cast(sum3 as sql_variant)
			WHEN 'Sum4To6 DESC' THEN cast(Sum4To6 as sql_variant)
			WHEN 'Sum7To18 DESC' THEN cast(Sum7To18 as sql_variant)
			WHEN 'Sum19To65 DESC' THEN cast(Sum19To65 as sql_variant)
			WHEN 'Sum66 DESC' THEN cast(sum66 as sql_variant)
			
		END DESC) AS Row,
		MahozNum,MahozName, RashutID,RashutName,MitkanNum,MitkanName,MitkanAddress
        ,sumAll,sum3,Sum4To6,Sum7To18,Sum19To65,sum66 from cteCount
        ) a
      WHERE  Row BETWEEN @intStartRow AND @intEndRow
	  ORDER BY Row
end