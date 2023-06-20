using Microsoft.EntityFrameworkCore;
using NAGPDemoWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


/* Db Context dependency injection */

var dbHost = Environment.GetEnvironmentVariable("mysql_url");
var dbName = Environment.GetEnvironmentVariable("db_name"); 
var dbUser = Environment.GetEnvironmentVariable("db_username"); 
var dbPassword = Environment.GetEnvironmentVariable("db_password"); 
var dbPort = Environment.GetEnvironmentVariable("db_Port"); 

var connectionString = $"server={dbHost};port={dbPort};database={dbName};user={dbUser};password={dbPassword}";
builder.Services.AddDbContext<DemoUserDbContext>(o => o.UseMySQL(connectionString));

/* ================================= */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

