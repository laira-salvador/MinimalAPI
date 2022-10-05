if not exists (select 1 from dbo.Command)
begin
	Insert into dbo.[Command] (Platform,CommandDesc,Command)
	Values
	('dotnet', 'add package', 'dotnet add [<project>] package <PACKAGE_NAME>'),
	('dotnet', 'initialize user secrets', 'dotnet user-secrets init'),
	('dotnet', 'EF add migrations', 'dotnet ef migrations add')
end