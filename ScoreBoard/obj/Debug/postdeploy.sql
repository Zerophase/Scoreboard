/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE
INTO Player AS Target
USING (VALUES
(1, 'Max', 'Rodderick'),
(2, 'John', 'Joe'),
(3, 'Ray', 'Johnson')
)
AS Source (PlayerID, FirstName, LastName)
ON Target.PlayerID = Source.PlayerID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (FirstName, LastName)
			VALUES (FirstName, LastName);

-- Add new field that stores hint for what the unit is.
-- look up swl rule for only one of 2 fields may be picked.
-- It's a constraint
--Look up inherited tables.
-- make ints
MERGE
INTO Score AS Target
USING (VALUES
(1, '24'),
(2, '5 hours'),
(3, '100'),
(4, '10'),
(5, '50'),
(6, '50'),
(7, '8 hours'),
(8, '200'),
(9, '5'),
(10, '25')
)
AS Source (ScoreID, ScoreName)
ON Target.ScoreID = Source.ScoreID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (ScoreName)
			VALUES (ScoreName);

MERGE
INTO ScoreLookUp AS Target
USING (VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 2, 1),
(7, 2, 2),
(8, 2, 3),
(9, 2, 4),
(10, 2, 5),
(11, 3, 1)
)
AS Source (ScoreLookUpID, PlayerID, ScoreID)
ON Target.ScoreLookUpID = Source.ScoreLookUpID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (PlayerID, ScoreID)
			VALUES (PlayerID, ScoreID);

-- need detail table that would link this from the Score Category to Score.
-- look into linking this to specific groups of monsters too.
-- look up cascade filters too.
-- to test write script
-- look up stored procedure
-- create seperate tables for breaking up multiple subcategory
-- look up Fiddler for seeing what's going on on the Secrete World site with classes http://www.telerik.com/fiddler
-- LInqpad and 101 linq samples
MERGE
INTO ScoreCategory AS Target
USING (VALUES
(1, 'Monsters Slayen', 1),
(2, 'Completion Time', 2),
(3, 'Overall Score', 3),
(4, 'Death Count', 4),
(5, 'Total Achievements', 5))
AS Source (ScoreCategoryID, Category, ScoreID)
ON Target.ScoreCategoryID = Source.ScoreCategoryID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (Category, ScoreID)
			VALUES (Category, ScoreID);

MERGE
INTO Friends AS Target
USING (VALUES
(1, 2),
(2, 1),
(1, 3),
(3, 1)
)
AS Source (PlayerID, FriendID)
ON Target.PlayerID = Source.PlayerID AND Target.FriendID = Source.FriendID 
WHEN not matched by TARGET
	THEN INSERT (PlayerID, FriendID)
			VALUES (PlayerID, FriendID);

MERGE
INTO ScoreGroup AS Target
USING (VALUES
(1, 1),
(2, 2),
(3,3)
)
AS Source (ScoreGroupID, PlayerID)
ON Target.ScoreGroupID = Source.ScoreGroupID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (PlayerID)
			VALUES (PlayerID);

MERGE
INTO ScoreGroupName AS Target
USING (VALUES
(1, 1, 'East US'),
(2, 2, 'East US'),
(3,3, 'East US')
--(3, 5, 'West US'),
--(4, 3, 'Central US'),
--(5, 4, 'All of US')
)
AS Source (ScoreGroupNameID, ScoreGroupID, NameOfScoreGroup)
ON Target.ScoreGroupNameID = Source.ScoreGroupNameID
WHEN NOT MATCHED BY TARGET
	THEN INSERT (ScoreGroupID, NameOfScoreGroup)
			VALUES (ScoreGroupID, NameOfScoreGroup);
GO
