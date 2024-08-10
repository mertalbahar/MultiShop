using MultiShop.Comment.Contexts;
using MultiShop.Comment.Infrastructures.Extensions;
using MultiShop.Comment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.DbContextRegistration(builder.Configuration);
builder.Services.RepositoryRegistration();
builder.Services.ServiceRegistration();

builder.Services.AddAutoMapper(typeof(Program));

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
