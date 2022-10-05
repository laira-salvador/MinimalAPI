CREATE PROCEDURE [dbo].[spCommand_Insert]
	@Platform varchar(10),
	@CommandDesc varchar(50),
	@Command varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[Command] (Platform,CommandDesc,Command)
	VALUES (@Platform,@CommandDesc,@Command)

END