﻿
create proc gs_getAgeType

as
begin
SELECT [AgeId]
      ,[BeginValue]
      ,[EndValue]
      ,[AgeName]
  FROM [MEDAM].[dbo].[AgeType]
end
