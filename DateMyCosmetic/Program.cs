using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using System.Reflection;
using Microsoft.OpenApi.Models;
using DataAccessLayer.Configuration;
using Microsoft.Extensions.Options;
using BusinessLayer.DTOs;
using DataAccessLayer.DataModels;
using DateMyCosmeticAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<IMongoSettings>(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DateMyCosmeticAPI", Version = "v1" });
});

// Register the AutoMapper profiles
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// MongoDB Context
builder.Services.AddSingleton<MongoContext>();

// Repositories
builder.Services.AddScoped<CosmeticRepository>();
builder.Services.AddScoped<TelegramAccountRepository>();

// Services
builder.Services.AddScoped<ICosmeticService, CosmeticService>();
builder.Services.AddScoped<ITelegramAccountService, TelegramAccountService>();
builder.Services.AddScoped<ITelegramAuthService, TelegramAuthService>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Cosmetic, CosmeticDTO>().ReverseMap();
    cfg.CreateMap<CosmeticDTO, CosmeticViewModel>().ReverseMap();
    cfg.CreateMap<TelegramAccount, TelegramAccountDTO>().ReverseMap();
    cfg.CreateMap<TelegramAccountDTO, TelegramAccountViewModel>().ReverseMap();
}, typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DateMyCosmeticAPI v1"));
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();