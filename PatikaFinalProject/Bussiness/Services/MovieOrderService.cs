﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PatikaFinalProject.Common;
using PatikaFinalProject.DataAccess;
using System.Linq;

namespace PatikaFinalProject.Bussiness.Services
{
    public class OrderMovieService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerCreateDTO> _createDtoValidator;
        public OrderMovieService(MyDbContext dbContext, IMapper mapper, IValidator<CustomerCreateDTO> createDtoValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<CustomerCreateDTO>> Create(CustomerCreateDTO dto)
        {
            ValidationResult validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _dbContext.Set<Customer>().AddAsync(_mapper.Map<Customer>(dto));
                await _dbContext.SaveChangesAsync();
                return new Response<CustomerCreateDTO>(ResponseType.Success, dto);
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

                return new Response<CustomerCreateDTO>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
