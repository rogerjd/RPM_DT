CREATE PROCEDURE [dbo].MovieNew
	@Title varchar(25),
	@Genre varchar(15),
	@ReleaseDate datetime,
	@Price decimal(5,2),
	@Rating varchar(5)
AS
	INSERT Movie ([Title], [Genre], [ReleaseDate], [Price], [Rating]) values (@Title, @Genre, @ReleaseDate, @Price, @Rating)
	
RETURN 0