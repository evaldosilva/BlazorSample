using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCoreWebAPI.Domain;
using WorkflowCoreWebAPI.Services;
using WorkflowCoreWebAPI.Workflow;
using WorkflowCoreWebAPI.Workflow.Steps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register used services
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
// To IOC Step, it has to be registered as a Transient as well
builder.Services.AddTransient<GetWeatherForecastStep>();

// Register Workflow Core
builder.Services.AddWorkflow();

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

// Register Workflow Core service
// To right start the workflow with the app launcher
//var host = app.Services.GetService<IWorkflowHost>();
//host.RegisterWorkflow<MainWorkflow>();
//host.Start();
//host.StartWorkflow("MainWorkflow", 1, null);
//host.Stop();

app.Run();
