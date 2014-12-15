CREATE FUNCTION dbo.SpaceBeforeCap
(
	@str NVARCHAR(MAX)
)
-- WITH ENCRYPTION, SCHEMABINDING, EXECUTE AS CALLER|SELF|OWNER|USER
RETURNS NVARCHAR(MAX)
AS BEGIN
DECLARE
	@i INT, @j INT,
	@cp NCHAR, @c0 NCHAR, @c1 NCHAR,
	@result NVARCHAR(MAX)
	SELECT
		@i = 1,
		@j = LEN(@str),
		@result = ''

		WHILE @i <= @j BEGIN  
        	SELECT
				@cp = SUBSTRING(@str, @i-1, 1),
				@c0 = SUBSTRING(@str, @i+0, 1),
				@c1 = SUBSTRING(@str, @i+1, 1)
				IF @c0 = UPPER(@c0) COLLATE Latin1_General_CS_AS
				BEGIN
				-- Add space if current is upper
				-- and either Previous or Next is lower
				-- add Previous or Current is not already a space
				IF @c0 = UPPER(@c0) COLLATE Latin1_General_CS_AS
				AND (
						@cp <> UPPER(@cp) COLLATE Latin1_General_CS_AS
					OR @c1 <> UPPER(@c1) COLLATE Latin1_General_CS_AS
				)
				AND @cp <> ' '
				AND @cp <> ' '
					SET @result = @result + ' '
				END -- if @c0

				SET @result = @result + @c0
				SET @i = @i + 1
        END -- while
        RETURN @result
END

SELECT DISTINCT dbo.SpaceBeforeCap(s.Discriminator) FROM Score s