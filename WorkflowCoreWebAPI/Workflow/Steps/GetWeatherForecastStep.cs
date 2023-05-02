using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCoreWebAPI.Domain;

namespace WorkflowCoreWebAPI.Workflow.Steps;

public class GetWeatherForecastStep : StepBody
{
    private readonly IWeatherForecastService _weatherForecastService;

    public GetWeatherForecastStep(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Hello world! I am getting weather forecast.");
        Console.WriteLine(string.Join(", ", _weatherForecastService.GetWeatherForacast().Select(x => x.Summary)));
        return ExecutionResult.Next();
    }
}