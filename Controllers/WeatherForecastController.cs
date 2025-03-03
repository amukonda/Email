using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Email.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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


        //public void TestConnectivity()
        //{
        //    string connectionString = "Data Source=LT-DEVELOPERS\\SQLEXPRESS;Initial Catalog=EmailService;User ID=localUser;Password=Password123;TrustServerCertificate=True;";
        //    //Data Source=LT-DEVELOPERS\\MSSQL16; UID=sa; Password=Password123;Database=CBZAgroyield_backup;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            Console.WriteLine("Connection successful. User ID and password are valid.");
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Login failed: " + ex.Message);
        //    }
        //}
    }
}
