
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

        public static IEnumerable<object[]> SplitCountData =>
                                                 new List<object[]>
                                                 {
                                                        new object[] { "a" , -1, new DateTime(2025,01,01) },
                                                        new object[] { "aa" , 2, new DateTime(0025,01,01) },
                                                        new object[] { "aaa", 3, new DateTime(9025,01,01) }
                                                 };

        [Theory, MemberData(nameof(SplitCountData))]
        public void Test1(string name, int price, DateTime date)
        {
            MovieCreateDTO dto = new MovieCreateDTO();

            dto.MovieName = name;
            dto.Price = price;
            dto.MovieYear = date;

            /*Action act = async () => await movieService.Create(dto);
            act.Should().Throw<InvalidOperationException>();
            FluentActions.Invoking(() => movieService.Create(dto)).Should().ThrowAsync<ArgumentNullException>();*/
            
            MovieCreateDTOValidator mcv= new MovieCreateDTOValidator();
            ValidationResult valRes =  mcv.Validate(dto);

            valRes.Errors.Should().Contain(new ValidationFailure());
        }
    }
}