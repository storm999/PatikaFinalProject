using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;

namespace PatikaFinalProject.Services
{
    public class MovieServices
    {
        private readonly MyDbContext _dbContext;
        //private readonly IMapper _mapper;
        /*private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;*/
        public MovieServices(MyDbContext dbContext)//, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _dbContext = dbContext;
            //_mapper = mapper;
            /*_createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;*/
        }

        public async Task<IResponse<MovieType>> GetById(int id)
        {
            List<MovieType> a = _dbContext.MovieType.ToList();
            var data = _dbContext.Set<MovieType>().Select(x => x.ID == id);
            if (data == null)
            {
                return new Response<MovieType>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return null;
        }

        /*
                public async Task<IResponse<List<MovieType>>> GetAll()
                {
                    var data = await _dbContext.Set<MovieType>().Select(x => x.ID == 0);
                    //var data = await _dbContext.Set<MovieType>().ToListAsync();
                    return new Response<List<MovieType>>(ResponseType.Success, data);
                }


                public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
                {
                    var validationResult = _createDtoValidator.Validate(dto);

                    if (validationResult.IsValid)
                    {
                        await _dbContext.Create(_mapper.Map<Work>(dto));
                        await _dbContext.SaveChanges();
                        return new Response<WorkCreateDto>(ResponseType.Success, dto);
                    }
                    else
                    {
                        List<CustomValidationError> errors = new();
                        foreach (var error in validationResult.Errors)
                        {
                            errors.Add(new()
                            {
                                ErrorMessage = error.ErrorMessage,
                                PropertyName = error.PropertyName
                            });
                        }

                        return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, errors);
                    }
                }

                public async Task<IResponse<IDto>> GetById<IDto>(int id)
                {

                    var data = _mapper.Map<IDto>(await _dbContext.GetByFilter(x => x.Id == id));
                    if (data == null)
                    {
                        return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
                    }
                    return new Response<IDto>(ResponseType.Success, data);
                }

                public async Task<IResponse> Remove(int id)
                {
                    var removedEntity = await _dbContext.GetByFilter(x => x.Id == id);
                    if (removedEntity != null)
                    {
                        _dbContext.Remove(removedEntity);
                        await _dbContext.SaveChanges();
                        return new Response(ResponseType.Success);
                    }
                    return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

                }


                public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
                {
                    var result = _updateDtoValidator.Validate(dto);
                    if (result.IsValid)
                    {
                        var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                        if (updatedEntity != null)
                        {
                            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
                            await _uow.SaveChanges();
                            return new Response<WorkUpdateDto>(ResponseType.Success, dto);
                        }
                        return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
                    }
                    else
                    {
                        List<CustomValidationError> errors = new();
                        foreach (var error in result.Errors)
                        {
                            errors.Add(new()
                            {
                                ErrorMessage = error.ErrorMessage,
                                PropertyName = error.PropertyName
                            });
                        }

                        return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, errors);
                    }
                }*/
    }
}
