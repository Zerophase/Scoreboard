CREATE TABLE [dbo].[ScoreLookUp]
(
	ScoreLookUpID int identity(1,1) not null,
	PlayerID int not null,
	ScoreID int not null,
	primary key clustered (ScoreLookUpID asc), 
    CONSTRAINT [FK_ScoreLookUp_PlayerID] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_ScoreLookUp_ScoreID] FOREIGN KEY (ScoreID) REFERENCES Score(ScoreID)
)
