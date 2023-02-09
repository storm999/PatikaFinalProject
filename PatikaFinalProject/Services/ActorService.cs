using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using System.Linq;

namespace PatikaFinalProject.Services
{
    public class ActorService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<ActorCreateDTO> _createDtoValidator;
        public ActorService(MyDbContext dbContext, IMapper mapper, IValidator<ActorCreateDTO> createDtoValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<ActorCreateDTO>> Create(ActorCreateDTO dto)
        {
            ValidationResult validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _dbContext.Set<Actor>().AddAsync(_mapper.Map<Actor>(dto));
                await _dbContext.SaveChangesAsync();
                return new Response<ActorCreateDTO>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (ValidationFailure error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new Response<ActorCreateDTO>(ResponseType.ValidationError, dto, errors);
            }
        }
  

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = _dbContext.Set<Actor>().SingleOrDefault(x => x.ID == id);
            if (removedEntity != null)
            {
                _dbContext.Remove(removedEntity);
                await _dbContext.SaveChangesAsync();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<List<ActorDTO>>> GetAll()
        {
            List<ActorDTO> data = _mapper.Map<List<ActorDTO>>(await _dbContext.Set<Actor>().ToListAsync());
            return new Response<List<ActorDTO>>(ResponseType.Success, data);
        }


        public async Task<IResponse<WorkUpdateDto>> Update(Actor dto)
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
        }
    }
}
