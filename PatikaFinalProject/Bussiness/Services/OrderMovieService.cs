using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using System.Linq;
using System.Xml;

namespace PatikaFinalProject.Bussiness.Services
{
    public class OrderMovieService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderMovieService(MyDbContext dbContext, IMapper mapper, IValidator<OrderCreateDTO> createDtoValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IResponse<OrderCreateDTO>> Create(int MovieID)
        {
            OrderCreateDTO dto;
            Movie? retrievedMovie = _dbContext.Set<Movie>().SingleOrDefault(x => x.ID == MovieID);
            if (retrievedMovie != null)
            {
                dto = new OrderCreateDTO();
                dto.MovieID = MovieID;
                dto.OrderDate = DateTime.Now;
                dto.Price = retrievedMovie.Price;

                await _dbContext.Set<Order>().AddAsync(_mapper.Map<Order>(dto));
                await _dbContext.SaveChangesAsync();
                return new Response<OrderCreateDTO>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                errors.Add(new()
                {
                    ErrorMessage = "Movie not found"
                }); ;

                return new Response<OrderCreateDTO>(ResponseType.ValidationError, null, errors);
            }
        }
    }
}
