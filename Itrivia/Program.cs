using Itrivia.WebApi.Helpers;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Contracts.Repository;
using ITrivia.DataAccess.Repository;
using ITrivia.Domain.Management;
using ITrivia.Domain.Parameter;
using ITrivia.Domain.Security;
using ITrivia.Facade.User;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<ILabelDomain>(x => new LabelDomain(x.GetRequiredService<ILabelRepository>()));

builder.Services.AddScoped<IMessagelRepository,MessageRepository>();
builder.Services.AddScoped<IMessageDomain>(x => new MessageDomain(x.GetRequiredService<IMessagelRepository>()));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDomain>(x => new UserDomain(x.GetRequiredService<IUserRepository>()));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileDomain>(x => new ProfileDomain(x.GetRequiredService<IProfileRepository>()));


builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolDomain>(x => new RolDomain(x.GetRequiredService<IRolRepository>()));

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageDomain>(x => new ImageDomain(x.GetRequiredService<IImageRepository>()));

builder.Services.AddScoped<IFacadeUser>(x=> 
    new FacadeUser(x.GetRequiredService<IUserDomain>(), x.GetRequiredService<IProfileDomain>(), x.GetRequiredService<IRolDomain>(), x.GetRequiredService<IImageDomain>())
);


builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);
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
