# FARSbe

1. Install .NET SDK
Make sure .NET 8 SDK (or your project's version) is installed.

2. Restore NuGet Packages
dotnet restore

3. Set Up the Database
Update appsettings.json or appsettings.Development.json with their own SQL Server connection string.
Example:
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FarsDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

4. Apply Migrations
Run the following to create/update the database schema:
dotnet ef database update

If dotnet ef is not installed
dotnet tool install --global dotnet-ef

5. Run the Application
dotnet run
The API will be available at https://localhost:5001 (or as configured).
