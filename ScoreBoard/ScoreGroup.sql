CREATE TABLE [dbo].[ScoreGroup]
(
	ScoreGroupID INT Identity(1,1) NOT NULL PRIMARY KEY,
	PlayerID int not null, 
    CONSTRAINT [FK_ScoreGroup_ToPlayer] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID)
)
