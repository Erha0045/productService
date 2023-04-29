using Microsoft.EntityFrameworkCore;
using product_service.Data;
using product_service.Repo;
using DotNetEnv;
using product_service.RabbitMQ;

Env.Load();


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST");
        });
});


 /*#region Allow-Orgin
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            }
            );
            #endregion*/



// Add services to the container

// Configure the database connection for MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?
    .Replace("MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"))
    .Replace("MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// RabbitMQ
builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<RabbitMQProducer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WineQueries>();
builder.Services.AddScoped<WineCommands>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

//app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();