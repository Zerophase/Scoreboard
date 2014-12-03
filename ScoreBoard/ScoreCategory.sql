CREATE TABLE [dbo].[ScoreCategory]
(
	ScoreCategoryID int Identity(1,1) primary key not null, 
	Category Varchar(48) not null,
	ScoreID int not null,
    CONSTRAINT [FK_ScoreCategory_ToScore] FOREIGN KEY (ScoreID) REFERENCES Score(ScoreID)
)
