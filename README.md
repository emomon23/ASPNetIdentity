Based on the tutorial from https://github.com/tjoudeh/AspNetIdentity.WebApi.git

-	Open the Solution is VSS.  In the Web.Config, change the connection string “DefaultConnection”  to a server you have access too
o	Eg. server=localhost;User Id=userWhoHasCreateDBPermission;pwd=Password!;Persist Security Info=True;database=AspNetIdentity.WebApi
-	Open the file Migrations/Configuration.cs, Find the ‘Seed’ method and modify the initial user that is created to whatever you want the username/pwd to be.
-	In Visual Studio, from the NuGet Package Manager Console, run the following commands:
o	enable-migrations
o	add-migration InitialCreate
o	update-database
-	Verify the database has been created and the expected user has been created as well.
