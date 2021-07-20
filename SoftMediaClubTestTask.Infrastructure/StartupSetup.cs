using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoftMediaClubTestTask.Application.Interfaces.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Application.Interfaces.Commands.StudentCommands;
using SoftMediaClubTestTask.Application.Interfaces.Queries.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.Interfaces.Queries.StudentQueries;
using SoftMediaClubTestTask.Application.Queries.Interfaces.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Application.UseCases.AcademicPerformanceTypes;
using SoftMediaClubTestTask.Application.UseCases.Students;
using SoftMediaClubTestTask.Infrastructure.Commands.AcademicPerformanceTypeCommands;
using SoftMediaClubTestTask.Infrastructure.Commands.StudentCommands;
using SoftMediaClubTestTask.Infrastructure.Data;
using SoftMediaClubTestTask.Infrastructure.Interactors.AcademicPerformanceTypeInteractors;
using SoftMediaClubTestTask.Infrastructure.Interactors.StudentInteractors;
using SoftMediaClubTestTask.Infrastructure.Queries.AcademicPerformanceTypeQueries;
using SoftMediaClubTestTask.Infrastructure.Queries.StudentQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure
{
    public static class StartupSetup
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string connectionString)
        {
            // database context registration
            services.AddScoped<IGetAcademicPerformanceTypesQuery, GetAcademicPerformanceTypesQuery>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // queries dependencies registration
            services.AddScoped<IGetStudentQuery, GetStudentQuery>();
            services.AddScoped<IGetStudentsQuery, GetStudentsQuery>();
            services.AddScoped<IGetAcademicPerformanceTypeQuery, GetAcademicPerformanceTypeQuery>();
            services.AddScoped<IGetAcademicPerformanceTypesQuery, GetAcademicPerformanceTypesQuery>();
            services.AddScoped<IGetAcademicPerformanceTypeByCodeQuery, GetAcademicPerformanceTypeByCodeQuery>();

            // command dependencies registration
            services.AddScoped<ICreateAcademicPerformanceTypeCommand, CreateAcademicPerformanceTypeCommand>();
            services.AddScoped<IUpdateAcademicPerformanceTypeCommand, UpdateAcademicPerformanceTypeCommand>();
            services.AddScoped<IDeleteAcademicPerformanceTypeCommand, DeleteAcademicPerformanceTypeCommand>();
            services.AddScoped<ICreateStudentCommand, CreateStudentCommand>();
            services.AddScoped<IUpdateStudentCommand, UpdateStudentCommand>();
            services.AddScoped<IDeleteStudentCommand, DeleteStudentCommand>();

            // usecases
            services.AddScoped<ICreateAcademicPerformanceTypeUseCase, CreateAcademicPerformanceTypeInteractor>();
            services.AddScoped<IUpdateAcademicPerformanceTypeUseCase, UpdateAcademicPerformanceTypeInteractor>();
            services.AddScoped<IDeleteAcademicPerformanceTypeUseCase, DeleteAcademicPerformanceTypeInteractor>();
            services.AddScoped<IGetAcademicPerformanceTypeUseCase, GetAcademicPerformanceTypeInteractor>();
            services.AddScoped<IGetAcademicPerformanceTypesUseCase, GetAcademicPerformanceTypesInteractor>();
            services.AddScoped<ICreateStudentUseCase, CreateStudentInteractor>();
            services.AddScoped<IUpdateStudentUseCase, UpdateStudentInteractor>();
            services.AddScoped<IDeleteStudentUseCase, DeleteStudentInteractor>();
            services.AddScoped<IGetStudentUseCase, GetStudentInteractor>();
            services.AddScoped<IGetStudentsUseCase, GetStudentsInteractor>();
            return services;
        }
    }
}
