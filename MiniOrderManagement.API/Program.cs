using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniOrderManagement.Application.Interfaces;
using MiniOrderManagement.Infrastructure.Data;
using MiniOrderManagement.Infrastructure.UnitOfWork;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("MiniOrderManagement.Infrastructure")
    )
);


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(MiniOrderManagement.Application.AssemblyReference).Assembly));

builder.Services.AddValidatorsFromAssembly(
    typeof(MiniOrderManagement.Application.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();






