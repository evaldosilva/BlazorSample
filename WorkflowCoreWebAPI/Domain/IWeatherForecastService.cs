namespace WorkflowCoreWebAPI.Domain;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForacast();
}