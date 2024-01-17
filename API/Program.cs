using System.Text;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Authentication;
using Core.Services;
using Infrastructure.Context;
using Infrastructure.Jwt;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettingsEntity>(builder.Configuration.GetSection(nameof(MongoDbSettings)));
builder.Services.AddSingleton<IProviderService, ProviderService>();
builder.Services.AddSingleton<IProviderRepository, ProviderRepository>();
builder.Services.AddSingleton<IContext, Context>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IJwtServices, JwtService>();


//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Cors",
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Cors");

app.MapControllers();

app.Run();
