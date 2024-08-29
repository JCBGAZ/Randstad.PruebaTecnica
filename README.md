# Products API project

Randstad - Test Software Developer

## Technologies Used

- **Backend**: .NET 8 (using clean architecture with the Repository design pattern.)
- **Database**: SQLite
- **ORM**: EntityFramework.Core
- **Tests**: xUnit

open powershell terminal
Code First is used for database generation, step to generate the migration and update of the database.

open powershell terminal

![Alt text](Images/PowerShell.png?raw=true "PowerShell")

```bash
cd src
cd .\Randstad.PruebaTecnica.API\
dotnet ef migrations add "InitialVersion" -p "..\Randstad.PruebaTecnica.Infrastructure" -o "..\Randstad.PruebaTecnica.Infrastructure\Data\Migrations"
dotnet ef database update -p "..\Randstad.PruebaTecnica.Infrastructure"
```
