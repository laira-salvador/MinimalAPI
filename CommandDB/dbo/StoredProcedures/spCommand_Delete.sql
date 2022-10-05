CREATE PROCEDURE [dbo].[spCommand_Delete]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Command]
	WHERE Id = @Id
END
