using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using ProyectoCurso.BackEnd.Data.Repositories;
using ProyectoCurso.BackEnd.Services.PerfilPersonal;
using ProyectoCurso.BackEnd.ServicesDependencies.Services.PerfilPersonal;
using ProyectoCurso.Shared.Data.Db;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Servicios con dependencia
builder.Services.AddDataProtection();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<DbConnection>(a => new MySqlConnection("Server=127.0.0.1;Port=4306;Database=proyectoCurso;Uid=root;password=test;"));
builder.Services.AddScoped<TransactionalWrapper>();
builder.Services.AddScoped<PerfilPersonalRepository>();
builder.Services.AddScoped<IGetPerfilPersonalDependencies, GetPerfilPersonalDependencies>();
builder.Services.AddScoped<IPostPerfilPersonalDependencies, PostPerfilPersonalDependencies>();
builder.Services.AddScoped<GetPerfilPersonal>();
builder.Services.AddScoped<PostPerfilPersonal>();

// Fin Servicios con dependencia
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
