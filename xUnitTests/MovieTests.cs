using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaFinalProject.Bussiness.Services;
using PatikaFinalProject.DataAccess;
using PatikaFinalProject.Services.Mapper;
using PatikaFinalProject.Services.Validators;
using Xunit.Abstractions;

namespace xUnitTests
{
    public class TestsBase  
    {
        protected MyDbContext _dbContext;
        protected IMapper mapper;

        public TestsBase( )
        {
            _dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseSqlServer("Data Source=Dell; Initial Catalog=patikaFinalProject; Integrated Security=true; TrustServerCertificate=True;").Options );
            MapperConfiguration configuration = new MapperConfiguration(opt => {
                                                                                    opt.AddProfile(new CustomerProfile());
                                                                                    opt.AddProfile(new ActorProfile());
                                                                                    opt.AddProfile(new DirectorProfile());
                                                                                    opt.AddProfile(new MovieProfile());
                                                                                    opt.AddProfile(new OrderMovieProfile());
                                                                                });
            mapper = configuration.CreateMapper();
        }
    }

    public class MovieTests : TestsBase
    {
        private MovieService movieService;

        public MovieTests()
        {
            movieService = new MovieService(_dbContext, mapper, new MovieCreateDTOValidator(), new MovieDTOValidator());
        }
        
        public static IEnumerable<object[]> SplitCountData =>
                                                 new List<object[]>
                                                 {
                                                        new object[] { "a" , 1, new DateTime(2020,01,01) },
                                                        new object[] { "aaa" , -1, new DateTime(2020,01,01) },
                                                        new object[] { "aaa", 2, new DateTime(2025,01,01) },
                                                        new object[] { "aaa", 1, new DateTime(1799,01,01) }
                                                 };

        [Theory, MemberData(nameof(SplitCountData))]
        public void Test1(string name, int price, DateTime date)
        {
            MovieCreateDTO dto = new MovieCreateDTO();
            
            dto.MovieName = name;
            dto.Price = price;
            dto.MovieYear = date;
            
            
            /*Func<Task> act = async () => await movieService.Create(dto);
            act.Should().NotThrowAsync<InvalidOperationException>();*/
            
            //FluentActions.Invoking(() => movieService.Create(dto)).Should().ThrowAsync<ArgumentNullException>().Result.And.Message;
            
            MovieCreateDTOValidator mcv= new MovieCreateDTOValidator();
            ValidationResult valRes =  mcv.Validate(dto);
            valRes.Errors.Count.Should().BeGreaterThan(0);
            //valRes.Errors.Should().Contain(new ValidationFailure("Price", "'Price' must be greater than or equal to '0'."));

        }
    }
}