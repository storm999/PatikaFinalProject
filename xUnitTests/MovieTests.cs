
using FluentAssertions;
using FluentValidation.Results;
using PatikaFinalProject.Bussiness.Services;
using PatikaFinalProject.DataAccess;
using PatikaFinalProject.Services.Validators;

namespace xUnitTests
{
    public class MovieTests 
    {
        private MovieService movieService;

        public MovieTests(MovieService ms)
        {
            movieService = ms;
        }

        [Fact]
        public void Test1()
        {
            MovieCreateDTO dto = new MovieCreateDTO();

            dto.MovieName = "a";
            dto.Price = -1;
            dto.MovieYear = new DateTime(2025,01,01);

            /*Action act = async () => await movieService.Create(dto);
            act.Should().Throw<InvalidOperationException>();
            FluentActions.Invoking(() => movieService.Create(dto)).Should().ThrowAsync<ArgumentNullException>();*/
            
            MovieCreateDTOValidator mcv= new MovieCreateDTOValidator();
            ValidationResult valRes =  mcv.Validate(dto);

            valRes.Errors.Should().Contain(new ValidationFailure());
        }
    }
}