using DVar.PList.Api.Requests.Pricelists;
using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Persistence;
using DVar.PList.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace DVar.PriceList.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IPricelistRepository repository,
    IUnitOfWork unitOfWork,
    ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePricelistRequest request)
    {
        var pricelist = new Pricelist
        {
            Name = request.Name,
            CustomColumns = request.CustomColumns
        };

        repository.Create(pricelist);
        if (await unitOfWork.CompleteAsync()) return Ok(pricelist.Id);

        return BadRequest("Requst is bad");
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}