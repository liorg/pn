--use medam
CREATE VIEW Rashuyot_activ
AS
select distinct  r.RashutID,r.RashutName, r.Mahoz
from Mefunim m inner join Mitkanim mt
on m.MitkanID=mt.MitkanNum
inner join Rashuyot r
on mt.RashutID=r.RashutID