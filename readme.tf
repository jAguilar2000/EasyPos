## Migrations

rm Migrations/*_DbMigration.*; dotnet ef migrations add DbMigration; dotnet ef database update


## OTROS NO NECESARIOS DE EJECUTAR
dotnet ef migrations remove
dotnet ef migrations script -o NombreDelArchivo.sql
