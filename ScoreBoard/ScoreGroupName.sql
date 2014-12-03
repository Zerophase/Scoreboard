CREATE TABLE [dbo].[ScoreGroupName]
(
	ScoreGroupNameID INT identity(1,1) NOT NULL PRIMARY KEY,
	ScoreGroupID int not null,
	NameOfScoreGroup Varchar(48), 
    CONSTRAINT [FK_ScoreGroupName_ToScoreGroup] FOREIGN KEY (ScoreGroupID) REFERENCES ScoreGroup(ScoreGroupID)

)
