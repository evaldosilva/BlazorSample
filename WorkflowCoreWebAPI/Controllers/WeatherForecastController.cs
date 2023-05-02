using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using WorkflowCoreWebAPI.Domain;
using WorkflowCoreWebAPI.Workflow;

namespace WorkflowCoreWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;
    private readonly IWorkflowHost _workflowHost;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService, IWorkflowHost workflowHost)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
        _workflowHost = workflowHost;
    }

    [HttpGet]
    [Route("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        return _weatherForecastService.GetWeatherForacast();
    }

    [HttpGet]
    [Route("StartWorkflow")]
    public IActionResult StartWorkflow()
    {
        if (!_workflowHost.Registry.IsRegistered("MainWorkflow", 1))
        {
            _workflowHost.RegisterWorkflow<MainWorkflow>();
            _workflowHost.Start();
        }

        _workflowHost.StartWorkflow("MainWorkflow");

        //Console.WriteLine(_workflowHost.Registry.con);

        return Ok();
    }
}