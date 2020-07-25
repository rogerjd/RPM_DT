CREATE PROCEDURE [dbo].MovieUpdate
	@Id int,
	@Title varchar(25),
	@Genre varchar(15),
	@ReleaseDate datetime,
	@Price decimal(5,2),
	@Rating varchar(5)
AS
	UPDATE Movie
	SET Title = @Title, Genre = @Genre, ReleaseDate = @ReleaseDate, Price = @Price, 
		Rating = @Rating 
	WHERE
	  ID = @Id
