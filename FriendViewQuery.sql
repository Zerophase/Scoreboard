CREATE VIEW FriendRelations AS
SELECT p1.AccountName AS FriendName, p.AccountName AS PlayerName FROM Player p
INNER JOIN FriendsPlayer fp
ON p.PlayerID = fp.Friends_PlayerID
INNER JOIN Player p1
ON p1.PlayerID = fp.Friends_PlayerID2
INNER JOIN Friends f
ON f.PlayerID = fp.Friends_PlayerID AND f.PlayerID2 = fp.Friends_PlayerID2

DECLARE @Fname NVARCHAR(48) = 'FireBelow'
SELECT FriendName, 1 AS grp FROM(

SELECT * FROM FriendRelations
WHERE PlayerName = @Fname) AS g
UNION
SELECT PlayerName, 2 AS	 grp2 FROM(

SELECT * FROM FriendRelations
WHERE PlayerName = @Fname) AS h
ORDER BY grp DESC
