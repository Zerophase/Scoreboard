CREATE TABLE [dbo].[Player]
(
	PlayerID int IDENTITY(1,1) Not Null primary key,
	FirstName varchar(48) null,
	LastName varchar(48) null,
	--primary key clustered (PlayerID ASC)
)
