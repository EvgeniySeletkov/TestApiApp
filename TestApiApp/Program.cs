using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TestApiApp;
using TestApiApp.Database;
using TestApiApp.Extensions;
using TestApiApp.Models.User;
using TestApiApp.Options;
using TestApiApp.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services
    .AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString(ApplicationConstants.APPLICATION_CONTEXT)));
builder.Services
    .AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

builder.Services.Configure<BearerTokenOptions>(configuration.GetSection(ApplicationConstants.TOKEN_OPTIONS));

builder.Services.AddSwagger();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidIssuer = configuration[ApplicationConstants.TOKEN_OPTIONS_ISSUER],
        ValidAudience = configuration[ApplicationConstants.TOKEN_OPTIONS_AUDIENCE],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(configuration[ApplicationConstants.TOKEN_OPTIONS_ISSUE_SIGNING_KEY])),
    };
});

builder.Services.AddRepositories();
builder.Services.AddCustomServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

