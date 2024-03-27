using Microsoft.EntityFrameworkCore;
using WhatsUpMon.Api.Data;
using WhatsUpMon.Api.Interfaces;
using WhatsUpMon.Api.Middleware;
using WhatsUpMon.Api.Repository;

var builder = WebApplication.CreateBuilder(args);


var connectionString = null as string;
// If we are in Development mode, the full connection string isn't set.
// Developers must set the individual environment variables to connect to the database.
if (builder.Environment.IsDevelopment())
{
    var mysqlHost = Environment.GetEnvironmentVariable("MYSQL_HOST");
    var mysqlPort = Environment.GetEnvironmentVariable("MYSQL_PORT");
    var mysqlDatabase = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
    var mysqlUser = Environment.GetEnvironmentVariable("MYSQL_USER");
    var mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");

    if (string.IsNullOrEmpty(mysqlHost) || string.IsNullOrEmpty(mysqlPort) || string.IsNullOrEmpty(mysqlDatabase) ||
        string.IsNullOrEmpty(mysqlUser) || string.IsNullOrEmpty(mysqlPassword))
    {
        Console.WriteLine("One or more MySQL environment variables are not set.");
        Console.WriteLine("Please set the environment variables MYSQL_HOST, MYSQL_PORT, MYSQL_DATABASE, MYSQL_USER, MYSQL_PASSWORD.");
        Console.WriteLine("Exiting...");
        Environment.Exit(1);
    }

    connectionString = $"Server={mysqlHost};Port={mysqlPort};Database={mysqlDatabase};User={mysqlUser};Password={mysqlPassword};";
    Console.WriteLine("Db connection string found via individual environment variables.");
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}
else
{
    // This should be set in docker-compose.yml.
    connectionString = Environment.GetEnvironmentVariable("WHATSUPMON_DATABASE");
    if (!string.IsNullOrEmpty(connectionString))
    {
        builder.Services.AddDbContext<ApplicationDBContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
    else
    {
        Console.WriteLine("No database connection string was configured in your docker-compose.yml.");
        Console.WriteLine("Please set the environment variable WHATSUPMON_DATABASE .");
        Console.WriteLine("Exiting...");
        Environment.Exit(1);
    }
}

// Configure Kestrel (web server) to listen on port 4200 with HTTP
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(System.Net.IPAddress.Any, 4200); // Listen on port 4200
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
// We may want to use swagger in production for our API documentation ??
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // app.UseExceptionHandler("/error");  // This is a built in, we are using our own exception handling middleware
    app.UseMiddleware<ExceptionHandlingMiddleware>();   // Exception handling should be one of the first middleware registered
}

// Not needed since we're not using HTTPS
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

