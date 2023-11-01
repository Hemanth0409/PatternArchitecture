
using Microsoft.EntityFrameworkCore;
using PatternArch.Business;
using PatternArch.Persistence.IRepository;
using PatternArch.Persistence.Models;
using PatternArch.Persistence.Repository;
using ReelTalkReviews.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataCheckContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CFAConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(UserInfo));
builder.Services.AddSingleton<ExceptionHandling>();
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
app.ExceptionHandling();

app.Run();
