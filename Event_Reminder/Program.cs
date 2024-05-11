// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Event_Reminder.Entities;
using Event_Reminder.Interfaces;
using Event_Reminder.Services;
using Event_Reminder.Application.Requests;

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");
configurationBuilder.AddUserSecrets(Assembly.GetExecutingAssembly());
var configuration = configurationBuilder.Build();

HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder();
hostApplicationBuilder.Logging.AddConsole();
hostApplicationBuilder.Services.AddSingleton(configuration);
hostApplicationBuilder.Services.AddSingleton<IGoogleCalendarService,GoogleCalendarService>();
hostApplicationBuilder.Services.AddSingleton<IGMailService,GMailService>();

hostApplicationBuilder.Services.AddDbContext<EventReminderDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("Event_Reminder")
));

hostApplicationBuilder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var host = hostApplicationBuilder.Build();

var mediator = host.Services.GetRequiredService<IMediator>();
await mediator.Send(new SampleRequest());