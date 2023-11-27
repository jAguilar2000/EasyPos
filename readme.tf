## Migrations

dotnet ef migrations remove

rm Migrations/*_DbMigration.*; dotnet ef migrations add DbMigration; dotnet ef database update

dotnet ef migrations script -o NombreDelArchivo.sql
