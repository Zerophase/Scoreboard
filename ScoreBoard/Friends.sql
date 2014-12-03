CREATE TABLE [dbo].[Friends]
(
	PlayerID int not null,
	FriendID int Not null,
    CONSTRAINT [FK_Friends_PlayerID] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Friends_FriendID] FOREIGN KEY (FriendID) REFERENCES Player(PlayerID),
	Primary key(PlayerID, FriendID)
)
