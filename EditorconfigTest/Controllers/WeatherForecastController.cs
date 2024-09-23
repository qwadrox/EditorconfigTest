using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EditorconfigTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private IAsyncDisposable? _weatherForecasts;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Nullable warning
            int[]? mightbenull = null;
            if (mightbenull?.Length > 0) {
                this._logger.Log(LogLevel.Warning, "");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    // Use PascalCase for classes and methods
    public class ClientActivity
    {
        public void ClearStatistics()
        {
            //...
        }
        public void CalculateStatistics()
        {
            //...
        }
    }

    //2. Do use camelCasing for method arguments and local variables:
    public class UserLog
    {
        public void Add(LogLevel logEvent)
        {

            // ...
        }
    }
    //Why: consistent with the Microsoft's .NET Framework and easy to read.

    // Do not use Hungarian notation or any other type identification in identifiers
    // Correct
    public class UserLog2 {
        int _counter;
         string _name = "";
        // Avoid
        int _iCounter;
        public string StrName =string.Empty;

        //4. Do not use Screaming Caps for constants or readonly variables:
        // Correct
        public const string ShippingType = "DropShip";
        // Avoid
        public const string SHIPPINGTYPE = "DropShip";

        // Correct
        public DateTime ClientAppointment;
        public TimeSpan CimeLeft;
        // Avoid
        public DateTime Client_Appointment;
        public TimeSpan Time_Left;
    }

    public enum CoinEnum  // Error: Enum type names should not end with 'Enum'
    {
        Penny,
        Nickel,
        Dime,
        Quarter,
        Dollar
    }

    // Why: consistent with the Microsoft's .NET Framework and Visual Studio IDE makes determining types very easy (via tooltips). In general, you want to avoid type indicators in any identifier.
}
