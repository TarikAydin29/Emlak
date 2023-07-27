using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Emlak.DAL.Abstract;
using Emlak.DAL.Concrete;
using Emlak.Entity.Concrete;
using Emlak.Entity.DBSettings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

builder.Services.AddSingleton<IDbSettings>(x => x.GetRequiredService<IOptions<DbSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(m => new MongoClient(builder.Configuration.GetValue<string>("DbSettings:ConnectionString")));

builder.Services.AddIdentity<AppUser, AppRole>()
        .AddMongoDbStores<AppUser, AppRole, Guid>
(
builder.Configuration.GetValue<string>("DbSettings:ConnectionString"),builder.Configuration.GetValue<string>("DbSettings:DatabaseName")
);


builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IAgentService, AgentService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
