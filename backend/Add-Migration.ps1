param ([Parameter(Mandatory)]$migrationName)

dotnet ef migrations add $migrationName --project ./Backend.Infrastructure --startup-project ./Backend.WebApi --output-dir Persistence\Migrations