SELECT
	AccountName,
	OverallScore
FROM dbo.Player AS p
INNER JOIN dbo.Score AS s
	ON PlayerID = Player_PlayerID
WHERE p.OverallScore_ID = s.ID
ORDER BY OverallScore DESC

SELECT AccountName, CompletionTime FROM	dbo.Player p
INNER JOIN dbo.Score s
ON p.PlayerID = s.Player_PlayerID
WHERE p.CompletionTime_ID = s.ID
ORDER BY s.CompletionTime ASC