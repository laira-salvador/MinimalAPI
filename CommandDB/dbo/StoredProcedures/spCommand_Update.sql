CREATE PROCEDURE [dbo].[spCommand_Update]
	@Id int,
    @Platform varchar(10),
	@CommandDesc varchar(50),
	@Command varchar(300)
AS
BEGIN
	UPDATE [dbo].[Command]
	SET Platform = @Platform, CommandDesc = @CommandDesc, Command = @Command
	WHERE Id = @Id
END
