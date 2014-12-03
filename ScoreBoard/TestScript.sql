

create view friendRelations as

Select p2.FirstName as friendFirst, p2.LastName as friendlast, p.FirstName as PlayerFirst, p.LastName as playerlast from Friends as F
Inner join Player as p
ON p.PlayerID = f.FriendID
Inner join Player as p2
on p2.PlayerID = f.PlayerID
--where p.FirstName = @Fname
--order by p.FirstName asc, p.LastName asc

-- Look up Unpivot
declare @Fname nvarchar(48) = 'Max'
select friendFirst, friendlast, 1 as grp from(

select * from friendRelations
where PlayerFirst = @Fname) as g
union
select PlayerFirst, playerlast, 2 as grp2 from(

select * from friendRelations
where PlayerFirst = @Fname) as h
order by grp desc