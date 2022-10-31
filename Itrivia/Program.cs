using Itrivia.WebApi.Helpers;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Contracts.Repository;
using ITrivia.Contracts.Security;
using ITrivia.DataAccess;
using ITrivia.DataAccess.Repository;
using ITrivia.Domain.Management;
using ITrivia.Domain.Parameter;
using ITrivia.Domain.Security;
using ITrivia.Facade.Managment;
using ITrivia.Facade.User;
using ITrivia.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDbContext<ITriviaDataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ITrivia.Database")));
builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<ILabelDomain>(x => new LabelDomain(x.GetRequiredService<ILabelRepository>()));

builder.Services.AddScoped<IMessagelRepository, MessageRepository>();
builder.Services.AddScoped<IMessageDomain>(x => new MessageDomain(x.GetRequiredService<IMessagelRepository>()));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDomain>(x => new UserDomain(x.GetRequiredService<IUserRepository>()));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileDomain>(x => new ProfileDomain(x.GetRequiredService<IProfileRepository>()));

builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolDomain>(x => new RolDomain(x.GetRequiredService<IRolRepository>()));

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageDomain>(x => new ImageDomain(x.GetRequiredService<IImageRepository>()));

builder.Services.AddScoped<IAutocompleteRepository, AutocompleteRepository>();
builder.Services.AddScoped<IAutocompleteDomain>(x => new AutocompleteDomain(x.GetRequiredService<IAutocompleteRepository>()));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryDomain>(x => new CategoryDomain(x.GetRequiredService<ICategoryRepository>()));

builder.Services.AddScoped<IChallengeRepository, ChallengeRepository>();
builder.Services.AddScoped<IChallengeDomain>(x => new ChallengeDomain(x.GetRequiredService<IChallengeRepository>()));

builder.Services.AddScoped<IGameTypeRepository, GameTypeRepository>();
builder.Services.AddScoped<IGameTypeDomain>(x => new GameTypeDomain(x.GetRequiredService<IGameTypeRepository>()));

builder.Services.AddScoped<IHistoryPDRepository, HistoryPDRepository>();
builder.Services.AddScoped<IHistoryPDDomain>(x => new HistoryPDDomain(x.GetRequiredService<IHistoryPDRepository>()));

builder.Services.AddScoped<IHistoryPSRepository, HistoryPSRepository>();
builder.Services.AddScoped<IHistoryPSDomain>(x => new HistoryPSDomain(x.GetRequiredService<IHistoryPSRepository>()));

builder.Services.AddScoped<IMultipleChoiceRepository, MultipleChoiceRepository>();
builder.Services.AddScoped<IMultipleChoiceDomain>(x => new MultipleChoiceDomain(x.GetRequiredService<IMultipleChoiceRepository>()));

builder.Services.AddScoped<IPairSelectionRepository, PairSelectionRepository>();
builder.Services.AddScoped<IPairSelectionDomain>(x => new PairSelectionDomain(x.GetRequiredService<IPairSelectionRepository>()));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileDomain>(x => new ProfileDomain(x.GetRequiredService<IProfileRepository>()));

builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ISectionDomain>(x => new SectionDomain(x.GetRequiredService<ISectionRepository>()));

builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<IStepDomain>(x => new StepDomain(x.GetRequiredService<IStepRepository>()));

builder.Services.AddScoped<IFacadeUser>(x =>
    new FacadeUser(x.GetRequiredService<IUserDomain>(), x.GetRequiredService<IProfileDomain>(), x.GetRequiredService<IRolDomain>(), x.GetRequiredService<IImageDomain>())
);

builder.Services.AddScoped<IFacadeAutoComplete>(x =>
    new FacadeAutoComplete(x.GetRequiredService<IAutocompleteDomain>(), x.GetRequiredService<IStepDomain>(), x.GetRequiredService<IChallengeDomain>(), x.GetRequiredService<ISectionDomain>())
);

builder.Services.AddScoped<IFacadeChallenge>(x =>
    new FacadeChallenge(x.GetRequiredService<IChallengeDomain>(), x.GetRequiredService<ISectionDomain>(), x.GetRequiredService<IAutocompleteDomain>(), x.GetRequiredService<IPairSelectionDomain>(), x.GetRequiredService<IMultipleChoiceDomain>(), x.GetRequiredService<IStepDomain>())
);

builder.Services.AddScoped<IFacadeMultipleChoice>(x =>
    new FacadeMultipleChoice(x.GetRequiredService<IMultipleChoiceDomain>(), x.GetRequiredService<IStepDomain>(), x.GetRequiredService<IChallengeDomain>(), x.GetRequiredService<ISectionDomain>())
);

builder.Services.AddScoped<IFacadePairSelection>(x =>
    new FacadePairSelection(x.GetRequiredService<IPairSelectionDomain>(), x.GetRequiredService<IStepDomain>(), x.GetRequiredService<IChallengeDomain>(), x.GetRequiredService<ISectionDomain>())
);

builder.Services.AddScoped<IFacadeProfile>(x =>
    new FacadeProfile(x.GetRequiredService<IProfileDomain>(), x.GetRequiredService<IChallengeDomain>(), x.GetRequiredService<IHistoryPDDomain>())
);

builder.Services.AddScoped<IFacadeSection>(x =>
    new FacadeSection(x.GetRequiredService<ISectionDomain>(), x.GetRequiredService<IUserDomain>())
);

builder.Services.AddScoped<IFacadeStep>(x =>
    new FacadeStep(x.GetRequiredService<IPairSelectionDomain>(), x.GetRequiredService<IMultipleChoiceDomain>(), x.GetRequiredService<IAutocompleteDomain>(), x.GetRequiredService<ISectionDomain>(), x.GetRequiredService<IStepDomain>(), x.GetRequiredService<IChallengeDomain>())
);

builder.Services.AddSingleton<IJWTHelper, JWTHelper>();

builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(ConstantsHelper.KeyForHmacSha256),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
