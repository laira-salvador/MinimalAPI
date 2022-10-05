CREATE PROCEDURE [dbo].[spCommand_GetById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Command]
	WHERE Id = @Id;
END
