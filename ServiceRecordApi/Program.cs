using Microsoft.EntityFrameworkCore;
using ServiceRecordApi.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ServiceRecordApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RecordContext>(opt => opt.UseInMemoryDatabase("Records"));
//builder.Services.AddDbContext<RecordContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IRecordRepository, RecordRepositoryImpl>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}
app.UseAuthorization();
app.MapControllers();
app.Run();
