CREATE PROCEDURE [dbo].[spCommand_GetByPlatform]
	@Platform varchar(10)
AS
BEGIN 
	SELECT * FROM [dbo].[Command]
	WHERE Platform = @Platform;
END
