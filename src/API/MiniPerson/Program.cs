using MiniPerson.API.Configurations;
using MiniPerson.Application;
using MiniPerson.Contract.Person.Queries;
using MiniPerson.Infrastructure.Patterns;
using MiniPerson.Infrastructure.Repositories.Person;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    WebRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    Args = args
});

builder.Services.AddDatabaseSetup(builder.Configuration);
builder.Services.ConfigureApplicationServices();
//builder.Services.AddInfrastructureRepositories(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

//builder.Services.AddMediatR(typeof(SaveProductCommand));



builder.Services.AddMemoryCache();

builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAPI",
      builder =>
      {
          //builder.WithOrigins("api.domain.com,DevTube.ir");
          builder.WithOrigins("*");
          builder.WithHeaders("*");
          builder.WithMethods("*");
      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
//app.UseCors("MyAPI");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();
