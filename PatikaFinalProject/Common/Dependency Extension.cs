using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaFinalProject.Controllers;
using PatikaFinalProject.DataAccess;
using PatikaFinalProject.Services;
using PatikaFinalProject.Services.Mapper;
using PatikaFinalProject.Services.Validators;


namespace PatikaFinalProject.Common
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            MapperConfiguration configuration = new MapperConfiguration(opt =>
                                                                {
                                                                    opt.AddProfile(new CustomerProfile());
                                                                });

            IMapper mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddDbContext<MyDbContext>(opt =>
            {
                opt.UseSqlServer("Data Source=Dell; Initial Catalog=patikaFinalProject; Integrated Security=true; TrustServerCertificate=True;"); ;
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
            services.AddSingleton(mapper);


            //services.AddScoped<DbContext, DbContext>();
            services.AddTransient<IValidator<CustomerCreateDTO>, CustomerCreateDTOValidator>();
            services.AddScoped<CustomerService, CustomerService>();
            
            services.AddScoped<MovieServices, MovieServices>();
            
            

        }
    }
}
