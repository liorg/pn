USE [MEDAM]
GO
/****** Object:  StoredProcedure [dbo].[gs_searchShiltonMekomi]    Script Date: 10/06/2013 14:29:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lior Grossman
-- Create date: 2013-09-11
-- Description:	Search Mefunim
-- =============================================
 --exec [gs_searchShiltonMekomi] 'MfLastName desc',1,15,@MfDateIncomeBegin='2013-08-11 08:00:01.000',@MfDateIncomeEnd='2013-08-08 12:00:00'
 --exec [gs_searchShiltonMekomi] 'MfLastName desc',1,15,@MfGender=' ז  '
 --exec [gs_searchShiltonMekomi] 'MfAge desc',1,15,@MfAge=5
--exec [gs_searchShiltonMekomi] 'MfAge desc',1,15,@MfFather='אילן '
  --exec [gs_searchShiltonMekomi] 'MfAge desc',1,15,@MfFather='איל '
ALTER PROCEDURE [dbo].[gs_searchShiltonMekomi]
    @pOrderBy nvarchar(100),@pCurrentPage int,@pPageSize tinyint
    ,@MfDateIncomeBegin datetime=null,@MfDateIncomeEnd datetime=null
    ,@MehozId INT =NULL,@MitkanNum INT =NULL,@RashutID INT =NULL
    ,@MfFirstName nvarchar(MAX)=NULL,@MfLastName nvarchar(MAX)=NULL,@MfGender nvarchar(MAX)=NULL
    ,@MefuneID bigint=null
    ,@MfFather nvarchar(MAX)=NULL
    ,@MfAge  INT =NULL
    ,@YeshuvNum  INT =NULL,@StNum INT =NULL,@MfAddHouseNum  nvarchar(MAX) =NULL,
    @IsMfDateOutcome BIT=NULL
    
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @intStartRow int;
	DECLARE @intEndRow int;
	DECLARE @BeginAgeValue int=null;
	DECLARE @EndAgeValue int=null;

--IF (@MfFather IS NOT NULL)
--BEGIN
--  set @MfFather=@MfFather+'%'
--end
IF (@MfAge IS NOT NULL)
BEGIN
SELECT @BeginAgeValue=[BeginValue]
      ,@EndAgeValue=[EndValue]
  FROM [MEDAM].[dbo].[AgeType]
  WHERE AgeId=@MfAge 
END


SET @intStartRow = (@pCurrentPage -1) * @pPageSize + 1;
SET @intEndRow   = @pCurrentPage * @pPageSize;   

SELECT Row,MefuneSysNum,MitkanID,MefuneID
        ,MfFirstName,MfLastName,MfGender,MfFather,MfAge
        ,IsMfDateOutcome
        ,MfAddHouseNum,StName,YeshuvName
	    --,ShiltonMekomiAddress
	    ,RashutName,RashutID
		,MitkanAddress,MitkanName,MitkanNum,MitkanPhone
		-- for debug
		,MfDateIncome
FROM
   (SELECT ROW_NUMBER() OVER (ORDER BY 
         CASE @pOrderBy
         	--WHEN 'MefuneID ASC'  THEN cast(MefuneID as sql_variant)
			WHEN 'MfLastName ASC'  THEN MfLastName
			WHEN 'MfFirstName ASC' THEN MfFirstName
			
		    WHEN 'MfAddHouseNum ASC' THEN cast(MfAddHouseNum as sql_variant)
			WHEN 'StName ASC' THEN StName
			WHEN 'YeshuvName ASC' THEN YeshuvName
			--WHEN 'ShiltonMekomiAddress ASC' THEN ISNULL(stname,'') + ' ' + ISNULL(cast(MfAddHouseNum as nvarchar(10)),'')+ ' '+ ISNULL(YeshuvName,'')		
			
			WHEN 'MfFather ASC' THEN MfFather
			WHEN 'MfGender ASC' THEN MfGender
			WHEN 'MfAge ASC' THEN cast(MfAge as sql_variant)
			WHEN 'IsMfDateOutcome ASC' THEN (CASE when MfDateOutcome is null then 1 else 0 END) 
			WHEN 'RashutName ASC' THEN rash.RashutName
			WHEN 'MitkanName ASC' THEN MitkanName
			WHEN 'MitkanAddress ASC' THEN m.Address
			WHEN 'MitkanPhone ASC' THEN m.Phone
		END ASC,
		CASE @pOrderBy
		--	WHEN 'MefuneID DESC'  THEN cast(MefuneID as sql_variant)
			WHEN 'MfLastName DESC' THEN MfLastName
			WHEN 'MfFirstName DESC' THEN MfFirstName
			
			WHEN 'MfAddHouseNum DESC' THEN cast(MfAddHouseNum as sql_variant)
			WHEN 'StName DESC' THEN StName
			WHEN 'YeshuvName DESC' THEN YeshuvName
			--WHEN 'ShiltonMekomiAddress DESC' THEN ISNULL(stname,'') + ' ' + ISNULL(cast(MfAddHouseNum as nvarchar(10)),'')+ ' '+ ISNULL(YeshuvName,'')	
			
			WHEN 'MfFather DESC' THEN MfFather
			WHEN 'MfGender DESC' THEN MfGender
			WHEN 'MfAge DESC' THEN cast(MfAge as sql_variant)
			WHEN 'IsMfDateOutcome DESC' THEN (CASE when MfDateOutcome is null then 1 else 0 END) 
			WHEN 'RashutName DESC' THEN rash.RashutName
			WHEN 'MitkanName DESC' THEN m.Address
			WHEN 'MitkanAddress DESC' THEN m.Address
			WHEN 'MitkanPhone DESC' THEN m.Phone
		END DESC) AS Row, 
		MitkanID,MefuneID,MfFirstName,MfLastName,MfGender,MfFather,MfAge
		,case when MfDateOutcome is null then 1 else 0 END AS IsMfDateOutcome 
		 --,ISNULL(stname,'') + ' ' + ISNULL(cast(MfAddHouseNum as nvarchar(10)),'')+ ' '+ ISNULL(YeshuvName,'') as ShiltonMekomiAddress		
		,stname,MfAddHouseNum,YeshuvName
		,rash.RashutName,rash.RashutID
		,m.Address as MitkanAddress,m.MitkanName,m.MitkanNum,m.Phone as MitkanPhone
		,MfDateIncome
		,MefuneSysNum
		FROM ShiltonMekomi sm
		LEFT JOIN dbo.Yeshuvim  y
		ON sm.MfAddCityCode=y.YeshuvNum
		outer apply (select StYeshuv,StNum,StName from dbo.Rehovot re where SM.MfAddStreetCode=re.StNum and re.StYeshuv=y.YeshuvNum) r
		LEFT JOIN  Mitkanim m
		on sm.MitkanID=m.MitkanNum
		inner join dbo.Rashuyot rash
		on rash.RashutID=m.RashutID
		
		where 
			  (@MfDateIncomeBegin is null or @MfDateIncomeBegin<=MfDateIncome) AND
			  (@MfDateIncomeEnd is null or @MfDateIncomeEnd>MfDateIncome) AND
			  (@MehozId is null or @MehozId=rash.Mahoz) AND
			  (@MitkanNum is null or @MitkanNum=m.MitkanNum) AND
			  (@RashutID is null or @RashutID=rash.RashutID)  AND
			  (@MfFirstName is null or ltrim(rtrim(MfFirstName)) like ltrim(rtrim(@MfFirstName))+'%')   AND
			  (@MfLastName is null or ltrim(rtrim(MfLastName)) like ltrim(rtrim(@MfLastName))+'%')  AND
			  (@MfGender is null or ltrim(rtrim(MfGender)) like ltrim(rtrim(@MfGender))+'%')  AND
			  (@MefuneID is null or @MefuneID=MefuneID)  AND
			  (@MfFather is null or  ltrim(rtrim(MfFather)) like ltrim(rtrim(@MfFather))+'%')  AND
			  (@BeginAgeValue is null or @BeginAgeValue<=MfAge)  AND
			  (@EndAgeValue is null or @EndAgeValue>=MfAge)  AND
			  (@YeshuvNum is null or @YeshuvNum=YeshuvNum)  AND
			  (@StNum is null or @StNum=StNum)  AND
			  (@MfAddHouseNum is null or LTRIM(RTRIM(@MfAddHouseNum))=LTRIM(RTRIM(MfAddHouseNum)))  AND
			  (@IsMfDateOutcome is null or ((MfDateOutcome IS NOT NULL AND @IsMfDateOutcome=1) OR (MfDateOutcome IS  NULL AND @IsMfDateOutcome=0)))  
		) AS ShiltonMekomiWithRowNumbers
			WHERE  Row BETWEEN @intStartRow AND @intEndRow
	    ORDER BY Row
	    
	    
	    select COUNT(*) as cnt 
	    FROM ShiltonMekomi sm
		LEFT JOIN dbo.Yeshuvim  y
		ON sm.MfAddCityCode=y.YeshuvNum
		outer apply (select StYeshuv,StNum,StName from dbo.Rehovot re where SM.MfAddStreetCode=re.StNum and re.StYeshuv=y.YeshuvNum) r
		LEFT JOIN  Mitkanim m
		on sm.MitkanID=m.MitkanNum
		inner join dbo.Rashuyot rash
		on rash.RashutID=m.RashutID
		where 
			  (@MfDateIncomeBegin is null or @MfDateIncomeBegin<=MfDateIncome) AND
			  (@MfDateIncomeEnd is null or @MfDateIncomeEnd>MfDateIncome) AND
			  (@MehozId is null or @MehozId=rash.Mahoz) AND
			  (@MitkanNum is null or @MitkanNum=m.MitkanNum) AND
			  (@RashutID is null or @RashutID=rash.RashutID)  AND
			  (@MfFirstName is null or ltrim(rtrim(MfFirstName)) like ltrim(rtrim(@MfFirstName))+'%')   AND
			  (@MfLastName is null or ltrim(rtrim(MfLastName)) like ltrim(rtrim(@MfLastName))+'%')  AND
			  (@MfGender is null or ltrim(rtrim(MfGender)) like ltrim(rtrim(@MfGender))+'%')  AND
			  (@MefuneID is null or @MefuneID=MefuneID)  AND
			  (@MfFather is null or  ltrim(rtrim(MfFather)) like ltrim(rtrim(@MfFather))+'%')  AND
			  (@BeginAgeValue is null or @BeginAgeValue<=MfAge)  AND
			  (@EndAgeValue is null or @EndAgeValue>=MfAge)  AND
			  (@YeshuvNum is null or @YeshuvNum=YeshuvNum)  AND
			  (@StNum is null or @StNum=StNum)  AND
			  (@MfAddHouseNum is null or LTRIM(RTRIM(@MfAddHouseNum))=LTRIM(RTRIM(MfAddHouseNum)))  AND
			  (@IsMfDateOutcome is null or ((MfDateOutcome IS NOT NULL AND @IsMfDateOutcome=1) OR (MfDateOutcome IS  NULL AND @IsMfDateOutcome=0)))  
		
END
