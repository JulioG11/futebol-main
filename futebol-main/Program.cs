using futebol.Data;
using futebol.IService;
using futebol.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options => options.UseNpgsql("Host=database-1.cyjv8ov9irv1.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;Username=postgres;Password=professor;"));

builder.Services.AddScoped<ITime, timeService>();
builder.Services.AddScoped<IJogador, jogadorService>();
builder.Services.AddScoped<ICompeticao, competicaoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
