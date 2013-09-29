CREATE VIEW mitkanim_activ 
as
select distinct r.Mahoz,m.RashutID,m.MitkanNum,m.MitkanName
from Mitkanim m inner join Rashuyot r
on m.RashutID=r.RashutID
inner join Mehozot mz
on r.Mahoz=mz.MahozNum
inner join Mefunim f
on m.MitkanNum=f.MitkanID