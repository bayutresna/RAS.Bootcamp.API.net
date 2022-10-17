using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.API.net.Datas.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dbmarketContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
