CREATE PROCEDURE [dbo].MovieGet
	@id int
AS
	SELECT *
	FROM Movie
	WHERE ID = @id
RETURN 0
