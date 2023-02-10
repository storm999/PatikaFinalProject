using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatikaFinalProject.Bussiness.Services;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using System.Data;

namespace PatikaFinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderMovieController : ControllerBase
    {
        /*OrderMovieService _OrderMovieService;

        private readonly ILogger<OrderMovieService> _logger;

        public OrderMovieController(ILogger<OrderMovieService> logger, OrderMovieService service)
        {
            _OrderMovieService = service;
            _logger = logger;
        }
        
        [Authorize(Roles = "Member")]
        [HttpPost("OrderMovie")]
        public async Task<IResponse<OrderMovieCreateDTO>> AddOrderMovie(OrderMovieCreateDTO newOrderMovie)
        {
            return await _OrderMovieService.Create(newOrderMovie);
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<IResponse<OrderMovieCreateDTO>> AddOrderMovie(OrderMovieCreateDTO newOrderMovie)
        {
            return await _OrderMovieService.Create(newOrderMovie);
        }*/


    }
}