param(
    [Parameter(Mandatory=$true)]
    [string]$ConnectionString
)

dotnet ef dbcontext scaffold $ConnectionString Npgsql.EntityFrameworkCore.PostgreSQL -o Models -c PlannerContext --context-dir .\ -f --no-onconfiguring