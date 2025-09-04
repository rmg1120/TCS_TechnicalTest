using TCSTest.Models;
using TCSTest.Repositories;
using TCSTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI: repositories
builder.Services.AddSingleton<IJsonRepository<Channel>, ChannelRepository>();
builder.Services.AddSingleton<IJsonRepository<ContentItem>, ContentRepository>();
builder.Services.AddSingleton<IJsonRepository<Schedule>, ScheduleRepository>();

// DI: services
builder.Services.AddSingleton<IChannelService, ChannelService>();
builder.Services.AddSingleton<IContentService, ContentService>();
builder.Services.AddSingleton<IScheduleService, ScheduleService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
