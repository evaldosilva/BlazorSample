using WorkflowCore.Interface;
using WorkflowCoreWebAPI.Workflow.Steps;

namespace WorkflowCoreWebAPI.Workflow;

public class MainWorkflow : IWorkflow
{
    public string Id => "MainWorkflow";

    public int Version => 1;

    public void Build(IWorkflowBuilder<object> builder)
    {
        builder.StartWith<GetWeatherForecastStep>()
               .Then<GetWeatherForecastStep>();
    }
}