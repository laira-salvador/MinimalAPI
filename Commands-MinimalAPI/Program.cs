using Commands_MinimalAPI;
using DataAccess.Data;
using DataAccess.DBAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<ICommandData, CommandData>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization( options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

var app = builder.Build();

app.Urls.Add("https://localhost:9000");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.AddCommandAPI();

app.Run();

