SELECT DISTINCT
	Discriminator
FROM dbo.Score

SELECT
	p.PlayerID, s.ID, p.OverallScore_ID, AccountName, OverallScore
FROM dbo.Player AS	 p
INNER JOIN dbo.Score AS	s ON	PlayerID = Player_PlayerID
WHERE p.OverallScore_ID = s.ID
ORDER BY OverallScore DESC

-- How to merge table id into Player
MERGE
INTO Player AS p
USING Score AS s
ON p.PlayerID = s.Player_PlayerID
	AND s.OverallScore IS NOT NULL
WHEN MATCHED
	THEN UPDATE
		SET p.OverallScore_ID = s.ID;

MERGE
INTO Player AS p
USING Score AS s
ON p.PlayerID = s.Player_PlayerID
	AND s.TotalAchievements IS NOT NULL
WHEN MATCHED
	THEN UPDATE
		SET p.OverallScore_ID = s.ID;

-- how to delete null values when wrong score assigned
DELETE FROM Player
WHERE AccountName IS NULL

