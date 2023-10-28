using App.Data.Context;
using App.Data.Uow;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Operation.Cqrs;
using Operation.Mapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperConfig());

});
builder.Services.AddSingleton(config.CreateMapper());           
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionstring=builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddDbContext<ApContext>(opts => opts.UseNpgsql(connectionstring));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
