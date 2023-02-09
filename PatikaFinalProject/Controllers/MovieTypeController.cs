using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using System.Data;
using PatikaFinalProject.Services;

namespace PatikaFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieServices _service;

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, MovieServices service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IResponse<MovieType>> Get()
        {
            /*SqlConnection sqlConnection = new SqlConnection(@"Data Source=Dell; Initial Catalog = patikaFinalProject; Integrated Security = true; TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.MovieType", sqlConnection);

            cmd.CommandType = CommandType.Text;


            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable questionTable = new DataTable();
            sqlConnection.Open();
            dataAdapter.Fill(questionTable);
            sqlConnection.Close();*/

            return await _service.GetById(0);
        }
    }
}