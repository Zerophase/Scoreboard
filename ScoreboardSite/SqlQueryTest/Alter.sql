UPDATE Player
SET Region_RegionID = 3
WHERE PlayerID = 4 OR PlayerID = 7 OR PlayerID = 8 OR PlayerID = 10

ALTER TABLE Player
ADD CONSTRAINT Regin_RegionID FOREIGN KEY (Region_RegionID) references dbo.Region(RegionID);