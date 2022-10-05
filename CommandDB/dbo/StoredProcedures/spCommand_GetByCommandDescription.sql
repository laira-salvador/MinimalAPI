CREATE PROCEDURE [dbo].[spCommand_GetByCommandDescription]
	@Description varchar(50)
AS
BEGIN 
	SELECT * FROM [dbo].[Command] 
	WHERE CommandDesc LIKE '%'+@description+'%';
END
