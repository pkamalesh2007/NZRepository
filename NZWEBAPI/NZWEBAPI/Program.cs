using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(
    options => {
        options.SuppressAsyncSuffixInActionNames = false;
    }
);


builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a Valid JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id=JwtBearerDefaults.AuthenticationScheme,
            Type=ReferenceType.SecurityScheme,
        }
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme,new string[] {}}
    });

});
//Fluent Validation configurations

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
// endFluent Validation configurations 

//connection string
builder.Services.AddDbContext<NZDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZConnectionString"));
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();


//Code for dependency injection for WalkRepository
builder.Services.AddScoped<IWalkRepository, WalkRepository>();

builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();

builder.Services.AddScoped<ITokenHandler, NZWEBAPI.Repositories.TokenHandler>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Code for Authentication configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidateAudience= true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
