using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.DataAccess;
using ITrivia.DataAccess.Repository;
using ITrivia.Domain.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ITriviaDataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ITrivia.Database")));
builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<ILabelDomain>(x => new LabelDomain(x.GetRequiredService<ILabelRepository>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
